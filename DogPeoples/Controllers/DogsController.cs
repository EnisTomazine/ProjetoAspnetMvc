using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace DogPeoples.Controllers
{
    public class DogsController : Controller
    {
        public ActionResult ListaDogs()
        {
            ViewBag.Dogs = new Dogs().Lista();
            return View();
        }

        public ActionResult NovoDog()
        {
            return View();
        }

        [HttpPost]
        public void CriarDog()
        {
            var dog = new Dogs();
            dog.Nome = Request["nome"];
            dog.Raca = Request["raca"];
            dog.Salvar();
            Response.Redirect("/Dogs/ListaDogs");
        }
        public ActionResult EditarDog(int id)
        {
            var dog = Dogs.BuscaPorId(id);
            ViewBag.Dogs = dog;
            return View();
        }


        public void AlterarDog(int id)
        {
            try
            {
                var dog = new Dogs();
                dog.Id = Convert.ToInt32(id);
                dog.Nome = Request["nome"];
                dog.Raca = Request["raca"];
                dog.Salvar();

                TempData["Sucesso"] = "Alterado com sucesso";
            }
            catch
            {
                TempData["Erro"] = "Não pode ser alterado";
            }
            Response.Redirect("/Dogs/ListaDogs");
        }


        public void ExcluirDog(int id)
        {
            try
            {
                Dogs.Delete(id);
                TempData["Sucesso"] = "Nome excluido com sucesso";

            }
            catch
            {
                TempData["Erro"] = "Não foi possível excluir a Nome";
            }
            Response.Redirect("/Dogs/ListaDogs");
        }


    }
}