using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TextSaverWebApp.Repository;

namespace TextSaverWebApp.Controllers
{
    public class HomeController : Controller
    {

        private ITextDbRepository repository;
        public HomeController(ITextDbRepository repo)
        {
            repository = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetLastTextsAsync(3));
        }

        public async Task<IActionResult> SaveText([FromForm]string text)
        {
            await repository.AddTextAsync(text);
            return RedirectToAction("Index");
        }
    }
}
