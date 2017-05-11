using System.Collections.Generic;

namespace CollectionsEditor
{
    public class Table
    {
        public Table(string programName, string baseName, bool foreign, List<Field> fields)
        {
            ProgramName = programName;
            BaseName = baseName;
            Foreign = foreign;
            Fields = fields;
        }

        public string ProgramName { get; set; }
        public string BaseName { get; set; }
        public bool Foreign { get; set; }
        public List<Field> Fields { get; set; }
    }
}
