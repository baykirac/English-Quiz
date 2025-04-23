using WordApi.Domain.Entities;

namespace WordApi.Infrastructure.Repository.Interfaces
{
    public interface IWordRepository
    {
        Task<List<Words>> GetAll();
        Task<Words> GetById(int id);
        Task<Words> AddWord(Words _word);
        Task<Words> DeleteWord(Words word);
        Task<Words> UpdateWord(int id, string word);
    }
}
