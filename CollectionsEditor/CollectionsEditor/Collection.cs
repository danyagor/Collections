using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsEditor
{
    public class Collection
    {
        public Collection(string name, Table mainTable, List<Table> foreignTables)
        {
            Name = name;
            MainTable = mainTable;
            ForeignTables = foreignTables;
        }

        public string Name { get; set; }
        public Table MainTable { get; set; }
        public List<Table> ForeignTables { get; set; }
    }
}
