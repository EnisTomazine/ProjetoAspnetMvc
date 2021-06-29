using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace DogPeoples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Dono = new Dono().Lista();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            var dono = new Dono();
            dono.Nome = Request["nome"];
            dono.Salvar();
            Response.Redirect("/Home");
        }
        public ActionResult EditarDono(int id)
        {
            var dono = Dono.BuscaPorId(id);
            ViewBag.Dono = dono;
            return View();
        }

        public ActionResult EditaDogDono(int Id)
        {
            var dogs = new Dogs().Lista();
            ViewBag.DogId = new SelectList(dogs, "Id", "Nome");
            ViewBag.DonoId = Id;
            ViewBag.DogsDonos = new DogsDonos().ListaPorId(Id);
            var dono = Dono.BuscaPorId(Id);
            ViewBag.Dono = dono;
            return View();
        }

        /*public ActionResult EditarDogDonos(int id)
        {
            var dono = Dono.BuscaPorId(id);
            ViewBag.DonoID = id;
            return View();
        }
        */
        [HttpPost]
        public ActionResult EditaDogDono()
        {
            string IdDono = Request["DonoId"];
            string IdDog = Request["DogId"];
            try
            {
                var dogsDonos = new DogsDonos();
                dogsDonos.IdDono = Convert.ToInt32(IdDono);
                dogsDonos.IdDog = Convert.ToInt32(IdDog);
                dogsDonos.Salvar();
            }
            catch
            {
                TempData["Erro"] = "Nome não pode ser alterado";
            }
            var dogs = new Dogs().Lista();
            ViewBag.DogId = new SelectList(dogs, "Id", "Nome");
            ViewBag.DonoId = Convert.ToInt32(IdDono);
            ViewBag.DogsDonos = new DogsDonos().ListaPorId(Convert.ToInt32(IdDono));
            var dono = Dono.BuscaPorId(Convert.ToInt32(IdDono));
            ViewBag.Dono = dono;
            //Response.Redirect("/Home/IdDono/EditaDogDono");
            return View();
        }


        public void AlterarDono(int id)
        {
            try
            {
                var dono = new Dono();
                dono.Id = Convert.ToInt32(id);
                dono.Nome = Request["nome"];
                dono.Salvar();

                TempData["Sucesso"] = "Nome Alterado com sucesso";
            }
            catch
            {
                TempData["Erro"] = "Nome não pode ser alterado";
            }
            Response.Redirect("/Home");
        }


        public void ExcluirDono(int id)
        {
            try
            {
                Dono.Delete(id);
                TempData["Sucesso"] = "Nome excluido com sucesso";

            }
            catch
            {
                TempData["Erro"] = "Não foi possível excluir a Nome";
            }
            Response.Redirect("/Home");
        }

        public void ExcluirDogDono(int idDono, int idDog)
        {
            try
            {
                DogsDonos.Delete(idDono, idDog);
                TempData["Sucesso"] = "Excluido com sucesso";

            }
            catch
            {
                TempData["Erro"] = "Não foi possível excluir";
            }
            Response.Redirect("/Home/" + idDono + "/EditaDogDono");
        }

        
    }
}