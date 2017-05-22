using System.Collections.Generic;

namespace CollectionsEditor
{
    public class Table
    {
        public Table(string programName, string baseName, bool foreign, bool fixedTable, List<Field> fields)
        {
            ProgramName = programName;
            BaseName = baseName;
            Foreign = foreign;
            Fixed = fixedTable;
            Fields = fields;
        }

        public Field this[int index] { get { return Fields[index]; } }

        public Field this[string baseName]
        {
            get
            {
                foreach (Field field in Fields)
                    if (field.BaseName == baseName)
                        return field;

                return null;
            }
        }

        public string ProgramName { get; set; }
        public string BaseName { get; set; }
        public bool Foreign { get; set; }
        public bool Fixed { get; set; }
        public List<Field> Fields { get; set; }
    }
}
