using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTrainingApp.Common.Entities
{
    public class LookupItem
    {
        public LookupItem() { }
        public LookupItem(string id) { Id = id; }
        public LookupItem(string id, string value) { Id = id; Value = value; }

        public string Id { get; set; }
        public string Value { get; set; }
    }
}
