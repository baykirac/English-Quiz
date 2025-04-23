using Microsoft.AspNetCore.Http.HttpResults;
using WordApi.Application.Interfaces;
using WordApi.Domain.Entities;
using WordApi.Domain.Resources;
using WordApi.Domain.Result;
using WordApi.Infrastructure.Repository.Interfaces;

namespace WordApi.Application
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<Result> GetAllWords()
        {
            try
            {
                var data = await _wordRepository.GetAll();
                return Result.ReturnOk(ReturnCodes.EnglishTest_ReturnedWordSuccessFully, data);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedWordError);
            }
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                var data = await _wordRepository.GetById(id);
                if(data == null)
                {
                    return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedWordError);
                }

                return Result.ReturnOk(ReturnCodes.EnglishTest_ReturnedWordSuccessFully, data);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_ReturnedWordError);
            }
        }

        public async Task<Result> AddWord(string word)
        {
            try
            {
                var _word = Words.Create(word);

                await _wordRepository.AddWord(_word);
                return Result.ReturnOk(ReturnCodes.EnglishTest_AddedWordSuccessFully, _word);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_AddedWordError);
            }
        }

        public async Task<Result> DeleteWord(int id)
        {
            try
            {
                var _word = await _wordRepository.GetById(id);
                await _wordRepository.DeleteWord(_word);

                return Result.ReturnOk(ReturnCodes.EnglishTest_DeletedWordSuccessFully, _word);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.EnglishTest_DeletedWordError);
            }
        }

        public async Task<Result> UpdateWord(int id, string word)
        {
            try
            {
                await _wordRepository.UpdateWord(id, word);

                return Result.ReturnOk(ReturnCodes.EnglishTest_UpdatedWordSuccessFully, word);
            }
            catch
            {
                return Result.ReturnError(ReturnCodes.String1EnglishTest_UpdatedWordError);
            }
        }
    }
}
