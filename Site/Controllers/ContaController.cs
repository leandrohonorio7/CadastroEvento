using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.Controllers
{
    public class ContaController : Controller
    {
        CadastroEventoBdEntities contexto = new CadastroEventoBdEntities();

        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModels model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var usuario = contexto.Usuario.Where(w => w.Email == model.Email).FirstOrDefault();

                if (usuario == null)
                    ModelState.AddModelError("Senha", "Usuário ou Senha Incorreto.");
                else
                {
                    if (model.Senha.Equals(usuario.Senha))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Senha", "Usuário ou Senha Incorreto.");
                    }
                }
            }
            return View("Index", model);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Conta");
        }
    }
}