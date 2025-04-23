using WordApi.Domain.Entities;
using WordApi.Domain.Result;

namespace WordApi.Application.Interfaces
{
    public interface IWordService
    {
        public Task<Result> GetAllWords();
        public Task<Result> GetById(int id);
        public Task<Result> AddWord(string word);
        public Task<Result> DeleteWord(int id);
        public Task<Result> UpdateWord(int id, string word);
    }
}
