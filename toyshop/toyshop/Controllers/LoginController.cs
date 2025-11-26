using Microsoft.AspNetCore.Mvc;
using toyshop.Models;

namespace toyshop.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            if (ValidateUser(model.Username, model.Password, model.Role))
            {
                HttpContext.Session.SetString("Username", model.Username); // Updated to use HttpContext.Session
                HttpContext.Session.SetString("Role", model.Role); // Updated to use HttpContext.Session
                HttpContext.Session.SetInt32("UserID", 1); // Updated to use HttpContext.Session

                return RedirectByRole(model.Role);
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác!");
                return View("Index", model);
            }
        }

        private bool ValidateUser(string username, string password, string role)
        {
            if (role == "admin" && username == "admin" && password == "123456") return true;
            if (role == "staff" && username == "employee1" && password == "123456") return true;
            if (role == "customer" && username == "user1" && password == "123456") return true;
            return false;
        }

        private ActionResult RedirectByRole(string role)
        {
            switch (role)
            {
                case "admin": return RedirectToAction("Dashboard", "Admin");
                case "staff": return RedirectToAction("Dashboard", "Staff");
                case "customer": return RedirectToAction("Index", "Products");
                default: return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); // Updated to use HttpContext.Session
            return RedirectToAction("Index");
        }
    }
}