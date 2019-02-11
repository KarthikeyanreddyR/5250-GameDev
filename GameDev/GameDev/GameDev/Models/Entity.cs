namespace GameDev.Models
{
    public class Entity<T> : BaseEntity<T> 
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }
    }
}
