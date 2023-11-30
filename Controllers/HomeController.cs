using FPT_BOOKSTORE.Areas.Identity.Data;
using FPT_BOOKSTORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FPT_BOOKSTORE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<FPT_BOOKSTOREUser> _userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<FPT_BOOKSTOREUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
            
        }

        public async Task<IActionResult> IndexAsync()
        {
            
           var user = await _userManager.GetUserAsync(this.User);
            if (user == null)
            {
                ViewData["Role"] = null;
                ViewData["FirstName"] = null;
                ViewData["LastName"] = null;
            }
            else
            {
                ViewData["Role"] = user.Role;
                ViewData["FirstName"] = user.FirstName;
                ViewData["LastName"] = user.LastName;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
