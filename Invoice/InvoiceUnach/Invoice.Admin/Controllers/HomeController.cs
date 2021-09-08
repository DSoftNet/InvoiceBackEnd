using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Invoice.Admin.Models;
using Invoice.Domain.Interfaces.Repositories;

namespace Invoice.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            return View(await Users());
        }

        #endregion

        #region Private Method

        private async Task<UserModel> Users()
        {
            var userModel = new UserModel();
            var users = await _userRepository.Get();

            userModel.InputUsers = new List<UserModel.InputUser>();

            foreach (var user in users)
            {
                userModel.InputUsers.Add(new UserModel.InputUser(user.Id, user.FirstName, user.SecondName,
                    user.FirstLastName, user.SecondLastName, user.Identification));
            }

            return userModel;
        }

        #endregion
    }
}