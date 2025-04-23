using WordApi.Infrastructure.BaseItems.Interfaces;

namespace WordApi.Infrastructure.BaseItems
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
