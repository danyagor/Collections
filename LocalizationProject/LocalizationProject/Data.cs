using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationProject
{
    class Data
    {
        public Data(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string key;
        public string value;
    }
}
