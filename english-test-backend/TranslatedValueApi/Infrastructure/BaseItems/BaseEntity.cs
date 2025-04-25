using TranslatedValueApi.Infrastructure.BaseItems.Interfaces;

namespace TranslatedValueApi.Infrastructure.BaseItems
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
