namespace CollectionsProject
{
    public class UserCollection
    {
        public UserCollection(Collection collectionType, string name)
        {
            CollectionType = collectionType;
            Name = name;
        }

        public Collection CollectionType { get; set; }
        public string Name { get; set; }
    }
}
