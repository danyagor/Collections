﻿namespace CollectionsProject
{
    public class Table
    {
        public Table(string programName, string baseName, bool foreign, bool fixedTable, Field[] fields)
        {
            ProgramName = programName;
            BaseName = baseName;
            Foreign = foreign;
            Fixed = fixedTable;
            Fields = fields;
        }

        public Field this[int index]
        {
            get
            {
                return Fields[index];
            }
        }

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


        public string ProgramName { get; }

        public string BaseName { get; }

        public bool Foreign { get; }

        public bool Fixed { get; }

        public Field[] Fields { get; }
    }
}
