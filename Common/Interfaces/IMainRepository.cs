using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitTrainingApp.Common.Entities;

namespace GitTrainingApp
{
    interface IMainRepository
    {
        ICollection<LookupItem> RetrieveAll();
        IQueryable<LookupItem> RetrieveQueryable();
        LookupItem RetrieveById(string id);
        void Save(LookupItem item);
        void RemoveById(string id);
    }
}
