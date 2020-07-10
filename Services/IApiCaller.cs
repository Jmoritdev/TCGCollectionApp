using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Services {
    public interface IApiCaller {
        Task<MTGCard> GetCard(string id);

        Task<MemoryStream> GetCardImage(string id);
    }
}