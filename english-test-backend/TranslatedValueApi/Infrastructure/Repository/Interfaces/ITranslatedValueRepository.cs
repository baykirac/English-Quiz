using TranslatedValueApi.Domain.Entites;

namespace TranslatedValueApi.Infrastructure.Repository.Interfaces
{
    public interface ITranslatedValueRepository
    {
        Task<List<Translations>> GetAll();
        Task<Translations> GetById(int id);
        Task<Translations> AddTranslation(Translations translation);
        Task<Translations> UpdateTranslation(int id, string newTranslationValue);
        Task<Translations> DeleteTranslation(int id);
    }
}
