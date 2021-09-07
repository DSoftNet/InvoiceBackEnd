using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}