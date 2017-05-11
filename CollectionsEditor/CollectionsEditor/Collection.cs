using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsEditor
{
    public class Collection
    {
        public Collection(string name, List<Table> tables)
        {
            Name = name;
            Tables = tables;
        }

        public string Name { get; set; }
        public List<Table> Tables { get; set; }
    }
}
