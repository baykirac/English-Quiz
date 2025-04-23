namespace WordApi.Infrastructure.BaseItems.Interfaces
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
