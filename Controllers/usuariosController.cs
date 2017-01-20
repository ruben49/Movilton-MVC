using movilton_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace movilton_mvc.Controllers
{
    public class usuariosController : Controller
    {
        //
        // GET: /usuarios/

        private BDMovilton bdo = new BDMovilton();


        public ActionResult Index()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return PartialView(bdo.usuarios.Where(user => user.usuario_activo == 1).ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        [HttpGet]
        public ActionResult Banear(int id)
        {
            if (ModelState.IsValid)
            {
                using (BDMovilton dc = new BDMovilton())
                {

                    usuarios update = dc.usuarios.Single(u => u.id_user == id);
                    update.estado = 0;
                    dc.Entry(update).State = EntityState.Modified;
                    dc.SaveChanges();

                    if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
                    {
                        var lista = bdo.perfil_empresa.First();
                        ViewBag.img = lista.logo;
                        return RedirectToAction("Index", "usuarios");
                    }
                    else
                    {
                        return RedirectToAction("LoginError", "Home");
                    }
                    
                }
                
            }

            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return RedirectToAction("Index", "usuarios");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            

        }

        [HttpGet]
        public ActionResult Desbanear(int id)
        {
            if (ModelState.IsValid)
            {
                using (BDMovilton dc = new BDMovilton())
                {

                    usuarios update = dc.usuarios.Single(u => u.id_user == id);
                    update.estado = 1;
                    dc.Entry(update).State = EntityState.Modified;
                    dc.SaveChanges();

                    if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
                    {
                        var lista = bdo.perfil_empresa.First();
                        ViewBag.img = lista.logo;
                        return RedirectToAction("Index", "usuarios");
                    }
                    else
                    {
                        return RedirectToAction("LoginError", "Home");
                    }

                    
                }

            }
           
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return RedirectToAction("Index", "usuarios");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }

            
        }

        public ActionResult AgregarUser()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return PartialView(bdo.usuarios.Where(user => user.usuario_activo == 0).ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }




        [HttpGet]
        public ActionResult Activar(int id)
        {
            if (ModelState.IsValid)
            {
                using (BDMovilton dc = new BDMovilton())
                {

                    usuarios update = dc.usuarios.Single(u => u.id_user == id);
                    update.usuario_activo = 1;
                    dc.Entry(update).State = EntityState.Modified;
                    dc.SaveChanges();
                    if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
                    {
                        var lista = bdo.perfil_empresa.First();
                        ViewBag.img = lista.logo;
                        return RedirectToAction("AgregarUser", "usuarios");
                    }
                    else
                    {
                        return RedirectToAction("LoginError", "Home");
                    }
                    
                }

            }

            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return RedirectToAction("AgregarUser", "usuarios");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }

            

        }

        [HttpGet]
        public ActionResult Desactivar(int id)
        {
            if (ModelState.IsValid)
            {
                using (BDMovilton dc = new BDMovilton())
                {

                    usuarios update = dc.usuarios.Single(u => u.id_user == id);
                    update.usuario_activo = 0;
                    dc.Entry(update).State = EntityState.Modified;
                    dc.SaveChanges();

                    if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
                    {
                        var lista = bdo.perfil_empresa.First();
                        ViewBag.img = lista.logo;
                        return RedirectToAction("Index", "usuarios");
                    }
                    else
                    {
                        return RedirectToAction("LoginError", "Home");
                    }

                    
                }

            }

            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return RedirectToAction("Index", "usuarios");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }

            
        }

        

    }
}
