using Microsoft.AspNetCore.Mvc;
using OA.Models.ViewModel;

namespace OA.Web.Controllers
{
    public class AccountController : Controller
    {
        #region User Signup
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserSignupViewModel userSignupViewModel)
        {
            //  ViewBag.status = "success";
            // ViewBag.msg = "Signup successfully";
            if (ModelState.IsValid)
            {

            }
            else
            {
                ModelState.AddModelError("", "");
            }
            return View(userSignupViewModel);
        }
        #endregion

        #region User Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
        #endregion

        #region Role Create

        public IActionResult Role()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Role(string roleName)
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        #endregion
    }
}
