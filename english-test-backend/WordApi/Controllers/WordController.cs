using Microsoft.AspNetCore.Mvc;
using WordApi.Application;
using WordApi.Application.Interfaces;
using WordApi.Domain.Entities;
using WordApi.Domain.Result;

namespace WordApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        public Task<Result> GetAllWords()
        {
            return _wordService.GetAllWords();
        }

        [HttpGet]
        public async Task<Result> GetById(int id)
        {
            return await _wordService.GetById(id);
        }

        [HttpPost]
        public async Task<Result> AddWord(string word)
        {
            return await _wordService.AddWord(word);
        }

        [HttpPost]
        public async Task<Result> DeleteWord(int id)
        {
            return await _wordService.DeleteWord(id);
        }
        
        [HttpPost]
        public async Task<Result> UpdateWord(int id, string newWord)
        {
            return await _wordService.UpdateWord(id, newWord);
        }
    }
}
