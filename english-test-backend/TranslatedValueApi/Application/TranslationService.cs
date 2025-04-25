using TranslatedValueApi.Application.Interfaces;
using TranslatedValueApi.Domain.Entites;
using TranslatedValueApi.Domain.Resources;
using TranslatedValueApi.Domain.Result;
using TranslatedValueApi.Infrastructure.Repository.Interfaces;

namespace TranslatedValueApi.Application
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslatedValueRepository _translationRepository;

        public TranslationService(ITranslatedValueRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public async Task<Result> GetAllTranslations()
        {
            try
            {
                var data = await _translationRepository.GetAll();

                if (data == null)
                {
                    return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedTranslationsError);
                }

                return Result.ReturnOk(ReturnCodes.EnglishTest_ReturnedTranslationsSuccessfully, data);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedTranslationsError);
            }
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                var data = await _translationRepository.GetById(id);

                if (data == null)
                {
                    return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedTranslationsError);
                }

                return Result.ReturnOk(ReturnCodes.EnglishTest_ReturnedTranslationsSuccessfully, data);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedTranslationsError);
            }
        }

        public async Task<Result> AddTranslation(string translationValue, int id)
        {
            try
            {
                var newTranslatedValue = Translations.Create(translationValue, id);
                await _translationRepository.AddTranslation(newTranslatedValue);

                return Result.ReturnOk(ReturnCodes.EnglishTest_AddedTranslationsSuccessfully, newTranslatedValue);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_AddedTranslationsError);
            }
        }

        public async Task<Result> UpdateTranslation(int id, string newTranslationValue)
        {
            try
            {
                var newTranslatedValue = await _translationRepository.UpdateTranslation(id, newTranslationValue);

                return Result.ReturnOk(ReturnCodes.EnglishTest_UpdatedTranslationsSuccessfully, newTranslatedValue);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_UpdatedTranslationsError);
            }
        }

        public async Task<Result> DeleteTranslation(int id)
        {
            try
            {
                var deletedTranslation = await _translationRepository.DeleteTranslation(id);

                return Result.ReturnOk(ReturnCodes.EnglishTest_DeletedTranslationsSuccessfully, deletedTranslation);
            }
            catch 
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_DeletedTranslationsError);
            }
        }
    }
}
