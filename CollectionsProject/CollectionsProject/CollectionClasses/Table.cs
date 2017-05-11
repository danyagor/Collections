namespace CollectionsProject
{
    public class Table
    {
        /// <summary>
        /// Конструктор для создания таблицы
        /// </summary>
        /// <param name="name">Имя таблицы</param>
        /// <param name="foreign">Внешняя таблица</param>
        /// <param name="fields">Поля в таблице</param>
        public Table(string programName, string baseName, bool foreign, Field[] fields)
        {
            ProgramName = programName;
            BaseName = baseName;
            Foreign = foreign;
            Fields = fields;
        }


        /// <summary>
        /// Возвращает поле по его индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Поле</returns>
        public Field this[int index]
        {
            get
            {
                return Fields[index];
            }
        }

        /// <summary>
        /// Возвращает поле по его имени в базе
        /// </summary>
        /// <param name="baseName">Имя в базе</param>
        /// <returns>Поле</returns>
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


        /// <summary>
        /// Имя таблицы в программе
        /// </summary>
        public string ProgramName { get; }

        /// <summary>
        /// Имя таблицы в базе
        /// </summary>
        public string BaseName { get; }

        /// <summary>
        /// Внешняя таблица
        /// </summary>
        public bool Foreign { get; }

        /// <summary>
        /// Поля в таблице
        /// </summary>
        public Field[] Fields { get; }
    }
}
