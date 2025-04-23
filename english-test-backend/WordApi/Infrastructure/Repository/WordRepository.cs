using Microsoft.EntityFrameworkCore;
using WordApi.Domain.Entities;
using WordApi.Infrastructure.Repository.Interfaces;

namespace WordApi.Infrastructure.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly AppDbContext _appDbContext;

        public WordRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Words>> GetAll() => _appDbContext.Words.ToListAsync();
        public Task<Words> GetById(int id) => _appDbContext.Words.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<Words> AddWord(Words _word)
        {
            await _appDbContext.Words.AddAsync(_word);
            await _appDbContext.SaveChangesAsync();

            return _word;
        }
        public async Task<Words> DeleteWord(Words word)
        {
            _appDbContext.Words.Remove(word);
            await _appDbContext.SaveChangesAsync();

            return word;
        }

        public async Task<Words> UpdateWord(int id, string word)
        {
            var _word = await _appDbContext.Words.FirstOrDefaultAsync(x => x.Id == id);
            
            _word.Update(word);

            await _appDbContext.SaveChangesAsync();
            return _word;
        }
    }
}
