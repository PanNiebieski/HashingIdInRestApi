using Microsoft.AspNetCore.Mvc;

namespace DocumentApiExample.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
