using movilton_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace movilton5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Tittle = "No te quedes atrás!";
            ViewBag.Message = "Con Movilton podemos integrar a todos y cada uno en toda nuestra comunidad y así lograr romper todo tipo de barreras gracias a la tecnología y al gran corazón de los voluntarios donde cada uno puede día a día aportar en la vida todos ya sea en ideas, ayuda o en aportes de todo tipo. Todos juntos y paso a paso podemos lograr lo que imaginemos ";

            return View();
        }

        public ActionResult About()
        {

            ViewBag.Msje1 = "Movilton es una aplicación móvil, una iniciativa para poder ayudar a todas las personas con discapacidad y que están en Teletón. Llega para enlazar todas las necesidades o actividades que en conjunto podamos tener.";
            ViewBag.Msje2 = "Abre un mundo ilimitado de soluciones rápidas y efectivas, donde usando la tecnología actual lo podemos logar sin limites a costo 0.";
            ViewBag.Msje3 = "La idea principal es lograr la integración y una homogeneidad entre el voluntariado y las personas ligadas a Teletón para tener soluciones rápidas y efectivas.";
            ViewBag.Msje4 = "La aplicación consiste en lo siguiente: Cuando alguien tenga algún problema, actividad o evento, por medio del mapa gps se puede indique lugar, su necesidad y el nivel de gravedad de esta. Realizado con exito estos pasos, el voluntariado más cercano puede tener acceso directo al problema y dar solución inmediata ya que se controlaran las distancias por medio de gps en el mapa, en donde el tiempo de respuesta es inmediato mejorando el servicio del voluntariado.";
            ViewBag.Msje5 = "Así logramos evitar los tiempos de espera. Con Movilton, alcanzar la solución e integración gracias a la cercanía, el compromiso de ustedes y del voluntariado será posible";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Si tienes dudas o sugerencias: ";

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Register(usuarios u)
        {
            if(ModelState.IsValid)
            {
                using(BDMovilton dc = new BDMovilton())
                {
                    var insert = dc.usuarios.Create();
                    insert.nombre_usuario = u.nombre_usuario;
                    insert.nombres = u.nombres;
                    insert.apellidos = u.apellidos;
                    insert.email = u.email;
                    insert.telefono = u.telefono;
                    insert.password = u.password;
                    insert.tipo_user = 2;
                    insert.estado = 1;
                    insert.usuario_activo = 0;
                    

                    dc.usuarios.Add(insert);
                    dc.SaveChanges();
                    return RedirectToAction("Login", "Home");

                }


            }
            return View();
        }




        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuarios u)
        {
            
            //Esta accion es para manejar el post (login)
            if(ModelState.IsValid)//Esto es para chequear la validez
            {
                using (BDMovilton dc = new BDMovilton())
                {

                    var v = dc.usuarios.Where(_fu => _fu.nombre_usuario.Equals(u.nombre_usuario) && _fu.password.Equals(u.password)).FirstOrDefault();

                    if(v != null)
                    {
                        if (v.usuario_activo == 1)
                        {
                            if (v.estado == 1)
                            {
                                FormsAuthentication.SetAuthCookie(v.id_user.ToString(), false);
                                FormsAuthentication.SetAuthCookie(v.nombre_usuario, false);
                                FormsAuthentication.SetAuthCookie(v.password, false);
                                FormsAuthentication.SetAuthCookie(v.tipo_user.ToString(), false);

                                Session["LogedUserID"] = v.id_user.ToString();
                                Session["LogedUserFullName"] = v.nombres.ToString();
                                Session["LogedUserType"] = v.tipo_user.ToString();
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                return RedirectToAction("ErrorBanned");
                            }

                        }
                        else
                        {
                            return RedirectToAction("ErrorInactive");
                        }
                    }
                
                }
            }

            return RedirectToAction("LoginError");
        }


        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LoginError()
        {
            return View();
        }

        public ActionResult ErrorBanned()
        {
            return View();
        }

        public ActionResult ErrorInactive()
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session["LogedUserID"] = null;
            Session["LogedUserFullName"] = null;
            Session["LogedUserType"] = null;



            return RedirectToAction("Index");
        }

        public ActionResult Panel()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                BDMovilton dc = new BDMovilton();
                var lista = dc.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return PartialView(dc.usuarios.ToList());
            }
            else
            {
                return RedirectToAction("LoginError");
            }
            
        }


        



    }
}
