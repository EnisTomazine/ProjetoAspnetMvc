using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DogPeoples
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "novo",
                "home/novo",
                new { controller = "Home", action = "Novo" }
            );

            routes.MapRoute(
                "criar",
                "home/criar",
                new { controller = "Home", action = "Criar" }
            ); 
            routes.MapRoute(
                "editarDono",
                "home/{id}/editarDono",
                new { controller = "Home", action = "EditarDono", id = 0 }
            );
            routes.MapRoute(
                "AlterarDono",
                "home/{id}/AlterarDono",
                new { controller = "Home", action = "AlterarDono", id = 0 }
            );
            routes.MapRoute(
                "ExcluirDono",
                "home/{id}/ExcluirDono",
                new { controller = "Home", action = "ExcluirDono", id = 0 }
            );
            routes.MapRoute(
                "ListaDogs",
                "caes/ListaDogs",
                new { controller = "Dogs", action = "ListaDogs"}
            );
            routes.MapRoute(
                "NovoDog",
                "caes/criar",
                new { controller = "Dogs", action = "Criar" }
            );
            routes.MapRoute(
                "CriarDog",
                "caes/CriarDog",
                new { controller = "Dogs", action = "CriarDog" }
            );
            routes.MapRoute(
                "ExcluirDog",
                "Dogs/{id}/ExcluirDog",
                new { controller = "Dogs", action = "ExcluirDog", id = 0 }
            );
            routes.MapRoute(
                "ExcluirDogDono",
                "home/{idDono}/{idDog}/ExcluirDogDono",
                new { controller = "Home", action = "ExcluirDogDono", idDono = 0, idDog = 0 }
            );
            routes.MapRoute(
               "EditarDog",
               "Dogs/{id}/EditarDog",
               new { controller = "Dogs", action = "EditarDog", id = 0 }
            );
            routes.MapRoute(
                "AlterarDog",
                "Dogs/{id}/AlterarDog",
                new { controller = "Dogs", action = "AlterarDog", id = 0 }
            );

            routes.MapRoute(
                "EditaDogDono",
                "home/{id}/EditaDogDono",
                new { controller = "Home", action = "EditaDogDono", id = 0 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        
        }
    }
}
