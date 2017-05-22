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

        public Table this[int index] { get { return Tables[index]; } }

        public Table this[string baseName]
        {
            get
            {
                foreach (Table table in Tables)
                    if (table.BaseName == baseName)
                        return table;

                return null;
            }
        }

        public string Name { get; set; }
        public List<Table> Tables { get; set; }
    }
}
