using Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    [Authorize]
    public class ExpositorController : Controller
    {
        CadastroEventoBdEntities contexto = new CadastroEventoBdEntities();

        // GET: Expositor
        public ActionResult Index()
        {
            var lista = contexto.Pessoa.Where(w => w.IdTipoPessoa == 2).ToList();

            ViewBag.SubTitulo = "Lista de Expositores";

            return View(lista);
        }

        public ActionResult Novo()
        {
            ViewBag.SubTitulo = "Novo Expositor";

            return View();
        }

        [HttpPost]
        public ActionResult Novo(ExpositorViewModels model)
        {
            ViewBag.SubTitulo = "Novo Expositor";

            if (ModelState.IsValid)
            {
                var pessoa = new Pessoa();

                pessoa.Nome = model.NomeCompleto;
                pessoa.IdTipoPessoa = 2;
                pessoa.Empresa = model.Empresa;
                pessoa.Cargo = model.Cargo;
                pessoa.CPF = model.CPF.Replace(".", "").Replace("-", "");
                pessoa.Telefone = model.Telefone;
                pessoa.Celular = model.Celular;
                pessoa.Email = model.Email;
                pessoa.Cidade = model.Cidade;
                pessoa.Estado = model.Estado;
                pessoa.DataCadastro = DateTime.Now;

                contexto.Pessoa.Add(pessoa);
                contexto.SaveChanges();

                ModelState.Clear();


                var Mensagem = new Mensagem
                {
                    Titulo = "Sucesso!",
                    Classe = "alert-success",
                    Texto = "Expositor Cadastrado com Sucesso!"
                };
                ViewBag.Mensagem = Mensagem;
            }
            return View();
        }
        
        public ActionResult Editar(int Id)
        {
            var pessoa = contexto.Pessoa.Find(Id);

            ExpositorViewModels model = new ExpositorViewModels();

            if (pessoa != null)
            {
                model.Id = pessoa.Id;
                model.NomeCompleto = pessoa.Nome;
                model.Empresa = pessoa.Empresa;
                model.Cargo = pessoa.Cargo;
                model.CPF = pessoa.CPF;
                model.Telefone = pessoa.Telefone;
                model.Celular = pessoa.Celular;
                model.Email = pessoa.Email;
                model.Cidade = pessoa.Cidade;
                model.Estado = pessoa.Estado;
            }

            ViewBag.SubTitulo = "Editar Expositor";

            return View("Novo", model);
        }

        [HttpPost]
        public ActionResult Editar(ExpositorViewModels model)
        {
            if (ModelState.IsValid)
            {
                var pessoa = contexto.Pessoa.Find(model.Id);

                pessoa.Nome = model.NomeCompleto;
                pessoa.Empresa = model.Empresa;
                pessoa.Cargo = model.Cargo;
                pessoa.CPF = model.CPF.Replace(".", "").Replace("-", "");
                pessoa.Telefone = model.Telefone;
                pessoa.Celular = model.Celular;
                pessoa.Email = model.Email;
                pessoa.Cidade = model.Cidade;
                pessoa.Estado = model.Estado;

                contexto.Entry(pessoa).State = EntityState.Modified;
                contexto.SaveChanges();

                ModelState.Clear();


                var Mensagem = new Mensagem
                {
                    Titulo = "Sucesso!",
                    Classe = "alert-success",
                    Texto = "Expositor Editado com Sucesso!"
                };
                ViewBag.Mensagem = Mensagem;
            }

            return View("Novo", model);
        }
    }
}