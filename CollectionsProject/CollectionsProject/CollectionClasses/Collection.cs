using System.Collections.Generic;

namespace CollectionsProject
{
    public class Collection
    {
        /// <summary>
        /// Конструктор для создания коллекции
        /// </summary>
        /// <param name="id">Идентификатор коллекции</param>
        /// <param name="name">Имя коллекции</param>
        /// <param name="tables">Таблицы коллекции</param>
        public Collection(int id, string name, Table mainTable, Table[] foreignTables)
        {
            Id = id;
            Name = name;
            MainTable = mainTable;
            ForeignTables = ForeignTables;
        }


        /// <summary>
        /// Возвращает внешнюю таблицу по её индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Таблица</returns>
        public Table this[int index]
        {
            get
            {
                return ForeignTables[index];
            }
        }

        /// <summary>
        /// Возвращает внешнюю таблицу по её имени в базе
        /// </summary>
        /// <param name="baseName">Имя таблицы в базе</param>
        /// <returns>Таблица</returns>
        public Table this[string baseName]
        {
            get
            {
                foreach (Table table in ForeignTables)
                    if (table.BaseName == baseName)
                        return table;

                return null;
            }
        }


        /// <summary>
        /// Идентификатор коллекции
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Имя коллекции
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Главная таблица коллекции
        /// </summary>
        public Table MainTable { get; }

        /// <summary>
        /// Внешние таблицы коллекции
        /// </summary>
        public Table[] ForeignTables { get; }
    }
}
