using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Visitantes()
        {
            return View();
        }

        public ActionResult Expositores()
        {
            return View();
        }

        public ActionResult Visitas()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GraficoCadastrados()
        {
            return Json("[{\"Valor\":1382,\"Descricao\":\"Visitantes\"},{\"Valor\":235,\"Descricao\":\"Expositores\"}]");
        }

        [HttpPost]
        public JsonResult GraficoVisitas()
        {
            return Json("[{\"visitas\":1382, \"visitantes\":1235, \"descricao\":\"25/12/2015\"},{\"visitas\":1165, \"visitantes\":936, \"descricao\":\"26/12/2015\"},{\"visitas\":1456, \"visitantes\":1335, \"descricao\":\"27/12/2015\"},{\"visitas\":1756, \"visitantes\":1556, \"descricao\":\"28/12/2015\"}]");
        }

        
    }
}