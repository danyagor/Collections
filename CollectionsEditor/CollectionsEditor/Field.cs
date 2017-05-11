﻿namespace CollectionsEditor
{
    public class Field
    {
        // Пустой конструктор
        public Field(string programName)
        {
            ProgramName = programName;
        }

        // Конструктор для полей в главной таблице
        public Field(string programName, string baseName, string type, string width, bool required, bool foreignKey, string foreignTable)
        {
            ProgramName = programName;
            BaseName = baseName;
            Type = type;
            Width = width;
            RequiredField = required;
            ForeignKey = foreignKey;
            ForeignTable = foreignTable;
        }

        // Конструктор для полей во внешней таблице
        public Field(string programName, string baseName, string type, string width, bool required, bool nameField)
        {
            ProgramName = programName;
            BaseName = baseName;
            Type = type;
            Width = width;
            RequiredField = required;
            NameField = nameField;
        }

        public string ProgramName { get; set; }
        public string BaseName { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }

        public bool RequiredField { get; set; }
        public bool ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public bool NameField { get; set; }
    }
}
