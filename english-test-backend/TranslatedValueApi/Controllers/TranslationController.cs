using Microsoft.AspNetCore.Mvc;
using TranslatedValueApi.Application.Interfaces;
using TranslatedValueApi.Domain.Result;

namespace TranslatedValueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet]
        public Task<Result> GetAll()
        {
            return _translationService.GetAllTranslations();
        }

        [HttpGet]
        public Task<Result> GetById(int id)
        {
            return _translationService.GetById(id);
        }

        [HttpPost]
        public Task<Result> AddTranslation(string translationValue, int id)
        {
            return _translationService.AddTranslation(translationValue, id);
        }

        [HttpPost]
        public Task<Result> UpdateTranslation(int id, string newTranslationValue)
        {
            return _translationService.UpdateTranslation(id, newTranslationValue);
        }

        [HttpPost]
        public Task<Result> DeleteTranslation(int id)
        {
            return _translationService.DeleteTranslation(id);
        }
    }
}
