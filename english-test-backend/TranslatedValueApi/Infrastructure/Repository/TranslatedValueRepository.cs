using Microsoft.EntityFrameworkCore;
using TranslatedValueApi.Domain.Entites;
using TranslatedValueApi.Infrastructure.Repository.Interfaces;

namespace TranslatedValueApi.Infrastructure.Repository
{
    public class TranslatedValueRepository : ITranslatedValueRepository
    {
        private readonly AppDbContext _appDbContext;

        public TranslatedValueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Translations>> GetAll() => _appDbContext.Translations.ToListAsync();

        public Task<Translations> GetById(int id) => _appDbContext.Translations.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Translations> AddTranslation(Translations translation)
        {
            await _appDbContext.Translations.AddAsync(translation);
            await _appDbContext.SaveChangesAsync();

            return translation;
        }

        public async Task<Translations> UpdateTranslation(int id, string newTranslationValue)
        {
            var translation = await GetById(id);
            translation.Update(newTranslationValue);

            await _appDbContext.SaveChangesAsync();

            return translation;
        }

        public async Task<Translations> DeleteTranslation(int id)
        {
            var translation = await GetById(id);

            _appDbContext.Translations.Remove(translation);
            await _appDbContext.SaveChangesAsync();

            return translation;
        }
    }
}
