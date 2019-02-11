using SQLite;

namespace GameDev.Models
{
    public class BaseEntity<T>
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Guid { get; set; }

        public BaseEntity()
        {
            Guid = System.Guid.NewGuid().ToString();
            Id = Guid;
        }
    }
}
