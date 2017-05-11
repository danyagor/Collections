namespace CollectionsProject
{
    public class Field
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Field()
        {
        }

        /// <summary>
        /// Конструктор для полей в главной таблице
        /// </summary>
        /// <param name="programName">Имя в программе</param>
        /// <param name="baseName">Имя в базе</param>
        /// <param name="type">Тип данных</param>
        /// <param name="width">Ширина колонки в программе</param>
        /// <param name="required">Обязательное поле</param>
        /// <param name="foreignKey">Внешний ключ</param>
        /// <param name="foreignTable">Имя внешней таблицы</param>
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

        /// <summary>
        /// Конструктор для полей во внешней таблице
        /// </summary>
        /// <param name="programName">Имя в программе</param>
        /// <param name="baseName">Имя в базе</param>
        /// <param name="type">Тип данных</param>
        /// <param name="width">Ширина колонки в программе</param>
        /// <param name="required">Обязательное поле</param>
        /// <param name="nameField">Именное поле</param>
        public Field(string programName, string baseName, string type, string width, bool required, bool nameField)
        {
            ProgramName = programName;
            BaseName = baseName;
            Type = type;
            Width = width;
            RequiredField = required;
            NameField = nameField;
        }


        /// <summary>
        /// Имя в программе
        /// </summary>
        public string ProgramName { get; }

        /// <summary>
        /// Имя в базе
        /// </summary>
        public string BaseName { get;}

        /// <summary>
        /// Тип данных
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Ширина колонки в программе
        /// </summary>
        public string Width { get; }

        /// <summary>
        /// Обязательное поле
        /// </summary>
        public bool RequiredField { get; }

        /// <summary>
        /// Внешний ключ
        /// </summary>
        public bool ForeignKey { get; }

        /// <summary>
        /// Имя внешней таблицы
        /// </summary>
        public string ForeignTable { get; }

        /// <summary>
        /// Именное поле
        /// </summary>
        public bool NameField { get; }
    }
}
