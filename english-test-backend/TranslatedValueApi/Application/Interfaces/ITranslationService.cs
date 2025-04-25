using TranslatedValueApi.Domain.Entites;
using TranslatedValueApi.Domain.Result;

namespace TranslatedValueApi.Application.Interfaces
{
    public interface ITranslationService
    {
        public Task<Result> GetAllTranslations();
        public Task<Result> GetById(int id);
        public Task<Result> AddTranslation(string translationValue, int id);
        public Task<Result> UpdateTranslation(int id, string newTranslationValue);
        public Task<Result> DeleteTranslation(int id);
    }
}
