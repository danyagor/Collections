namespace CollectionsEditor
{
    public class Field
    {
        // Конструктор для полей в главной таблице
        public Field(string programName, string baseName, bool foreignKey, string foreignTable)
        {
            ProgramName = programName;
            BaseName = baseName;
            ForeignKey = foreignKey;
            ForeignTable = foreignTable;
        }

        // Конструктор для полей во внешней таблице
        public Field(string programName, string baseName, bool nameField)
        {
            ProgramName = programName;
            BaseName = baseName;
            NameField = nameField;
        }

        public string ProgramName { get; set; }
        public string BaseName { get; set; }

        public bool ForeignKey { get; set; }
        public string ForeignTable { get; set; }

        public bool NameField { get; set; }
    }
}
