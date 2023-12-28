using CrudMvc.Data;
using CrudMvc.Models;
using CrudMvc.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudMvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuariorRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuariorRepositorio usuariorRepositorio)
        {
            _usuarioRepositorio = usuariorRepositorio;
        }
        // GET: UsuarioController
        public ActionResult Index()
        {
            List<Usuario> usuario = _usuarioRepositorio.BuscarTodos();
            return View(usuario);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contado, tente novamente! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuario, tente novamente! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            try
            {
                bool exclusaoSucesso = _usuarioRepositorio.Delete(id);

                if (exclusaoSucesso !=  false)
                {
                    TempData["MensagemSucesso"] = "Usuario deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos deletar seu contado";
                }
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contado, mais detalhes do erro{erro.Message}";
                return RedirectToAction("Index");
            }
        }

       
    }
}
