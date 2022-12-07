using Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Site.Controllers
{
    [Authorize]
    public class VisitanteController : Controller
    {
        CadastroEventoBdEntities contexto = new CadastroEventoBdEntities();

        // GET: Visitante
        public ActionResult Index()
        {
            var lista = contexto.Pessoa.Where(w => w.IdTipoPessoa == 1).ToList();

            ViewBag.SubTitulo = "Lista de Visitantes";

            return View(lista);
        }

        public ActionResult Novo()
        {
            ViewBag.Tipo = "N";

            var model = new VisitantesViewModels();
            model.EventoDia = GetDiasEvento();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Novo(VisitantesViewModels model)
        {
            if (ModelState.IsValid)
            {
                var pessoa = new Pessoa();

                pessoa.Nome = model.NomeCompleto;
                pessoa.IdTipoPessoa = 1;
                pessoa.Empresa = model.Empresa;
                pessoa.Cargo = model.Cargo;
                pessoa.CPF = model.CPF.Replace(".", "").Replace("-", "");
                pessoa.Telefone = model.Telefone;
                pessoa.Celular = model.Celular;
                pessoa.Email = model.Email;
                pessoa.CNPJ = model.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                pessoa.CEP = model.CEP;
                pessoa.Endereco = model.Endereco;
                pessoa.Numero = model.Numero.ToString();
                pessoa.Complemento = model.Complemento;
                pessoa.Bairro = model.Bairro;
                pessoa.Cidade = model.Cidade;
                pessoa.Estado = model.Estado;
                pessoa.DataCadastro = DateTime.Now;

                foreach (var dia in model.EventoDia.PostedDias.DiasIDs)
                {
                    pessoa.EventoDia.Add(contexto.EventoDia.Find(Convert.ToInt32(dia)));
                }

                contexto.Pessoa.Add(pessoa);
                contexto.SaveChanges();

                ModelState.Clear();              
                
                var Mensagem = new Mensagem
                {
                    Titulo = "Sucesso!",
                    Classe = "alert-success",
                    Texto = "Visitante Cadastrado com Sucesso!"
                };
                ViewBag.Mensagem = Mensagem;
                ViewBag.Tipo = "N";

            }

            var empty = new VisitantesViewModels();
            empty.EventoDia = GetDiasEvento();

            return View(empty);
        }

        public string BuscarVisitante(string cpf)
        {
            var pessoa = contexto.Pessoa.Where(w => w.CPF == cpf.Replace(".", "").Replace("-", "")).FirstOrDefault();

            var visitante = new VisitantesViewModels();

            if (pessoa != null)
            {
                visitante.Id = pessoa.Id;
                visitante.NomeCompleto = pessoa.Nome;
                visitante.CPF = pessoa.CPF;
                visitante.Empresa = pessoa.Empresa;
                visitante.Cargo = pessoa.Cargo;
                visitante.CNPJ = pessoa.CNPJ;
                visitante.Telefone = pessoa.Telefone;
                visitante.Celular = pessoa.Celular;
                visitante.Endereco = pessoa.Endereco;
                visitante.Numero = Convert.ToInt32(pessoa.Numero);
                visitante.Bairro = pessoa.Bairro;
                visitante.Cidade = pessoa.Cidade;
                visitante.Estado = pessoa.Estado;
                visitante.CEP = pessoa.CEP;
                visitante.Foto = Convert.ToBase64String(pessoa.Foto.FirstOrDefault().FileContent);
            };

            return new JavaScriptSerializer().Serialize(visitante);
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(string cpf)
        {
            var pessoa = contexto.Pessoa.Where(w => w.CPF == cpf.Replace(".", "").Replace("-", "")).FirstOrDefault();

            if (pessoa != null)
                Session["TirarFoto_IdVisitante"] = pessoa.Id;

            ViewBag.Pessoa = pessoa;

            return View();
        }

        public ActionResult TirarFoto()
        {
            return View();
        }

        public bool SalvarFoto()
        {
            var retorno = false;
            var IdVisitante = Convert.ToInt32(Session["TirarFoto_IdVisitante"]);
            var visitante = contexto.Pessoa.Find(IdVisitante);

            Stream fileStream = Request.Files[0].InputStream;
            byte[] documentBytes = new byte[fileStream.Length];
            fileStream.Read(documentBytes, 0, documentBytes.Length);

            if (visitante.Foto == null)
            {

                Foto foto = new Foto
                {
                    DataCriacao = DateTime.Now,
                    FileContent = documentBytes,
                    Ativo = true,
                    Nome = Request.Files[0].FileName,
                    Tamanho = Request.Files[0].ContentLength,
                    Tipo = Request.Files[0].ContentType,
                    IdPessoa = IdVisitante
                };

                contexto.Foto.Add(foto);
            }
            else
            {
                var foto = visitante.Foto.FirstOrDefault();

                foto.DataAlteracao = DateTime.Now;
                foto.FileContent = documentBytes;
                foto.Tamanho = Request.Files[0].ContentLength;
                foto.Tipo = Request.Files[0].ContentType;

                contexto.Entry(foto).State = EntityState.Modified;
            }

            var Mensagem = new Mensagem();

            if (contexto.SaveChanges() > 0)
            {
                Mensagem.Titulo = "Sucesso!";
                Mensagem.Classe = "alert-success";
                Mensagem.Texto = "Foto inserida com sucesso.";

                retorno = true;
            }

            TempData["Mensagem"] = Mensagem;

            return retorno;
        }

        [HttpGet]
        public ActionResult Foto(int? id)
        {
            var foto = contexto.Foto.Find(id);
            return File(foto.FileContent, foto.Tipo);

        }

        public ActionResult Editar(int Id)
        {
            var pessoa = contexto.Pessoa.Find(Id);

            var model = new VisitantesViewModels();

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
                model.CNPJ = pessoa.CNPJ;
                model.CEP = pessoa.CEP;
                model.Endereco = pessoa.Endereco;
                model.Numero = Convert.ToInt32(pessoa.Numero);
                model.Complemento = pessoa.Complemento;
                model.Bairro = pessoa.Bairro;
                model.Cidade = pessoa.Cidade;
                model.Estado = pessoa.Estado;
            }

            model.EventoDia = GetDiasEvento();
            model.EventoDia.SelectedDias = GetDiasVisitante(pessoa.Id);

            ViewBag.SubTitulo = "Editar Visitante";

            return View("Novo", model);
        }

        [HttpPost]
        public ActionResult Editar(VisitantesViewModels model)
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
                pessoa.CNPJ = model.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                pessoa.CEP = model.CEP;
                pessoa.Endereco = model.Endereco;
                pessoa.Numero = model.Numero.ToString();
                pessoa.Complemento = model.Complemento;
                pessoa.Bairro = model.Bairro;
                pessoa.Cidade = model.Cidade;
                pessoa.Estado = model.Estado;

                //Remover Dias
                while (pessoa.EventoDia.Count > 0)
                {
                    pessoa.EventoDia.Remove(pessoa.EventoDia.FirstOrDefault());
                }

                //Atualizar Dias
                foreach (var dia in model.EventoDia.PostedDias.DiasIDs)
                {
                    pessoa.EventoDia.Add(contexto.EventoDia.Find(Convert.ToInt32(dia)));
                }

                contexto.Entry(pessoa).State = EntityState.Modified;


                contexto.SaveChanges();

                ModelState.Clear();


                var Mensagem = new Mensagem
                {
                    Titulo = "Sucesso",
                    Classe = "alert-success",
                    Texto = "Visitante Editado com Sucesso!"
                };
                ViewBag.Mensagem = Mensagem;

            }

            model.EventoDia = GetDiasEvento();
            model.EventoDia.SelectedDias = GetDiasVisitante(model.Id);

            return View("Novo", model);
        }

        public ActionResult Detalhes(int Id)
        {
            var visitante = contexto.Pessoa.Find(Id);

            return View(visitante);

        }

        public ActionResult Controle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Controle(string cpf)
        {
            var pessoa = contexto.Pessoa.Where(w => w.CPF == cpf.Replace(".", "").Replace("-", "")).FirstOrDefault();

            //Verificar Foto
            //Verificar Dias de Entrada

            ViewBag.Pessoa = pessoa;

            return View();
        }

        private EventoDiaViewModels GetDiasEvento()
        {
            var diasV = new EventoDiaViewModels();
            var list = new List<DiasDeEvento>();

            foreach (var dia in contexto.EventoDia.ToList())
            {
                list.Add(new DiasDeEvento { Id = dia.Id, Name = dia.Data.ToString("d") });
            }

            diasV.AvailableDias = list;
            diasV.SelectedDias = new List<DiasDeEvento>();

            return diasV;
        }

        private List<DiasDeEvento> GetDiasVisitante(int Id)
        {
            var dias = contexto.Pessoa.Find(Id).EventoDia.ToList();
            var diasSelecionado = new List<DiasDeEvento>();

            foreach (var dia in dias)
            {
                diasSelecionado.Add(new DiasDeEvento { Id = dia.Id, Name = dia.Data.ToString("d") });
            }

            return diasSelecionado;
        }
    }
}