using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using parcialdpwa.DAL;
using parcialdpwa.Models;

namespace parcialdpwa.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiscContext db = new DiscContext();

        public ActionResult Index()
        {
            var reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                var EmpleadoID = reqCookies["EmnpleadoID"];
                if (EmpleadoID != null) return View();
            }

            return View("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(Empleado empleado)
        {
            ViewBag.Message = "";
            var emp = db.Empleados.Where(e => e.login.Equals(empleado.login) && e.clave.Equals(empleado.clave));
            if (emp.ToList().Count > 0)
            {
                var userInfo = new HttpCookie("userInfo");
                userInfo["UserName"] = emp.ToList().First().login;
                userInfo["EmnpleadoID"] = emp.ToList().First().ID.ToString();
                userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                Response.Cookies.Add(userInfo);
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}