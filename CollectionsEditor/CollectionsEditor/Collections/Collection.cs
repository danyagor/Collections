using System.Collections.Generic;

namespace CollectionsEditor
{
    public class Collection
    {
        public Collection(int id, string name, Table mainTable, Table[] foreignTables)
        {
            Id = id;
            Name = name;
            MainTable = mainTable;
            ForeignTables = foreignTables;
        }


        public Table this[int index]
        {
            get
            {
                return ForeignTables[index];
            }
        }

        public Table this[string baseName]
        {
            get
            {
                foreach (Table table in ForeignTables)
                    if (table.BaseName == baseName)
                        return table;

                return null;
            }
        }



        public int Id { get; }


        public string Name { get; }


        public Table MainTable { get; }


        public Table[] ForeignTables { get; }
    }
}
