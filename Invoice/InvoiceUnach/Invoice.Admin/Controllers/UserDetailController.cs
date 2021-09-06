using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Admin.Controllers
{
    public class UserDetailController : Controller
    {
        public IActionResult Index(Guid userId)
        {
            return View();
        }
    }
}