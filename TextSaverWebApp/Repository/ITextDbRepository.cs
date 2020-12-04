using System.Collections.Generic;
using System.Threading.Tasks;
using TextSaverWebApp.Models;

namespace TextSaverWebApp.Repository
{
    public interface ITextDbRepository
    {
        Task AddTextAsync(string text);
        Task AddTextAsync(TextEntity text);
        Task<TextEntity> GetTextAsync(int id);
        Task<IEnumerable<TextEntity>> GetLastTextsAsync(int count);
    }
}
