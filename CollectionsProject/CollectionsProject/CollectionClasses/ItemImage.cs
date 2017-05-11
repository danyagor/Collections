namespace CollectionsProject
{
    public class ItemImage
    {
        public ItemImage(byte[] imageBytes, string comment)
        {
            ImageBytes = imageBytes;
            Comment = comment;
        }

        public byte[] ImageBytes { get; set; }
        public string Comment { get; set; }
    }
}
