namespace CollectionsProject
{
    class CollectionTypes
    {
        /// <summary>
        /// Коллекции из файла
        /// </summary>
        public static Collection[] Collections;

        /// <summary>
        /// Статический конструктор, который заполняет массив коллекций при первом обращении к нему
        /// </summary>
        static CollectionTypes()
        {
            Collections = XmlHelper.GetAllCollections();
        }


        /// <summary>
        /// Возвращает коллекцию по её идентификатору
        /// </summary>
        /// <param name="id">Идентификатор коллекции</param>
        /// <returns>Коллекция</returns>
        public static Collection GetCollection(int id)
        {
            foreach (Collection collection in Collections)
                if (collection.Id == id)
                    return collection;

            return null;
        }

        /// <summary>
        /// Возвращает коллекцию по её имени
        /// </summary>
        /// <param name="name">Имя коллекци</param>
        /// <returns>Коллекция</returns>
        public static Collection GetCollection(string name)
        {
            foreach (Collection collection in Collections)
                if (collection.Name == name)
                    return collection;

            return null;
        }
    }
}
