using System.Collections.Generic;

namespace LocalizationProject
{
    class Category
    {
        public Category(string name, List<Data> strings)
        {
            Name = name;
            Strings = strings;
        }

        public string Name { get; set; }

        public List<Data> Strings { get; set; }
    }
}
