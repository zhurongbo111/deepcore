namespace DeepCore.DAL.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset UpdatedTime { get; set; }
    }
}
