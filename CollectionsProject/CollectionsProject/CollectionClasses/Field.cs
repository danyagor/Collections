namespace CollectionsProject
{
    public class Field
    {

        public Field(string programName, string baseName, bool foreignKey, string foreignTable)
        {
            ProgramName = programName;
            BaseName = baseName;
            ForeignKey = foreignKey;
            ForeignTable = foreignTable;
        }

        public Field(string programName, string baseName, bool nameField)
        {
            ProgramName = programName;
            BaseName = baseName;
            NameField = nameField;
        }

        public string ProgramName { get; }

        public string BaseName { get;}

        public bool ForeignKey { get; }


        public string ForeignTable { get; }

        public bool NameField { get; }
    }
}
