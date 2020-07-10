using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCGCollectionApp.Models;

namespace TCGCollectionApp.Data {
    interface ISetData {

        ICollection<MTGSet> GetSets();
    }
}
