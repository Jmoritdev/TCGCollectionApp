using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TCGCollectionApp.Services {
    internal interface IScopedCronJob {
        Task DoWork(CancellationToken stoppingToken);
    }
}
