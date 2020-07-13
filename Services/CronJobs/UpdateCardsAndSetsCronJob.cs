using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCGCollectionApp.Data;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Services {

    internal class UpdateCardsAndSetsCronJob : IScopedCronJob {
        private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly MTGApiCaller apiCaller;
        private readonly MTGSetData setData;
        private readonly MTGCardData cardData;

        private readonly TimeSpan frequency = TimeSpan.FromDays(1);

        public UpdateCardsAndSetsCronJob(ILogger<UpdateCardsAndSetsCronJob> logger, MTGApiCaller apiCaller, MTGSetData setData, MTGCardData cardData) {
            _logger = logger;
            this.apiCaller = apiCaller;
            this.setData = setData;
            this.cardData = cardData;
        }

        public async Task DoWork(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                executionCount++;

                Console.WriteLine("Getting all sets from api");
                string allSetsJson = apiCaller.GetAllCardSets().Result;

                dynamic helper = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(allSetsJson);
                ICollection<MTGSet> dbSets = setData.GetSets();

                foreach (var apiSet in helper.data) {
                    MTGSet dbSet = dbSets.Where(s => s.Code == (string)apiSet.code).FirstOrDefault();

                    if (dbSet == null) {
                        MTGSet s = Newtonsoft.Json.JsonConvert.DeserializeObject<MTGSet>(apiSet);
                        setData.AddSet(s);
                        Console.WriteLine("Added " + (string)apiSet.Name + " as a new set");
                    }
                }

                Console.WriteLine("Saving set changes...");
                setData.SaveChanges();

                Console.WriteLine("Finished updating sets, starting on cards");

                Console.WriteLine("Getting cards from api...");
                string allCardsJson = apiCaller.GetAllCards().Result;

                ICollection<MTGCard> apiCards = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<MTGCard>>(allCardsJson);

                Console.WriteLine("Converting to hash");
                //converting to hash allows us to loop quicker through all cards
                HashSet<string> apiCardIds = apiCards.Select(a => a.Id).ToHashSet<string>();
                HashSet<string> dbCardIds = cardData.GetAllIds(); //getting only ids from db instead of getting everything then only taking ids

                Console.WriteLine("Starting on cards");
                int count = 0;
                ICollection<MTGCard> cards = new List<MTGCard>();
                foreach (string apiCardId in apiCardIds) {

                    if (!dbCardIds.Contains(apiCardId)) {
                        cards.Add(apiCards.FirstOrDefault(c => c.Id == apiCardId));

                        //save every 100 to maintain speed
                        if (count % 100 == 0) {
                            Console.WriteLine("Quicksave ---------------------------------------------------------------");
                            cardData.AddMultiple(cards);
                            cardData.SaveChanges();
                            cards.Clear();
                        }
                        count++;
                    }
                }

                Console.WriteLine("Saved " + count + " new cards...");
                cardData.SaveChanges();

                Console.WriteLine("Database update complete.");

                await Task.Delay(frequency, stoppingToken);
            }
        }
    }
}
