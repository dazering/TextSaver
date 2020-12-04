using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TextSaverWebApp.DataBase;
using TextSaverWebApp.Models;

namespace TextSaverWebApp.Repository
{
    public class TextDbRepository : ITextDbRepository
    {
        private TextDbContext context;

        public TextDbRepository(TextDbContext cntx)
        {
            context = cntx;
        }

        public async Task AddTextAsync(string text)
        {
            var partedText = new TextEntity();
            partedText.SplitText(text);
            await context.TextEntities.AddAsync(partedText);
            await context.SaveChangesAsync();
        }

        public async Task AddTextAsync(TextEntity text)
        {
            await context.TextEntities.AddAsync(text);
            await context.SaveChangesAsync();
        }

        public async Task<TextEntity> GetTextAsync(int id)
        {
            var text = await context.TextEntities.Include(t => t.PartedTexts).FirstOrDefaultAsync(t => t.Id == id);
            return text;
        }

        public async Task<IEnumerable<TextEntity>> GetLastTextsAsync(int count)
        {
            var texts = await context.TextEntities.Include(t => t.PartedTexts).OrderByDescending(t => t.Id).Take(count).ToListAsync();
            return texts;
        }
    }
}
