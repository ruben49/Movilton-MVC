using movilton_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace movilton_mvc.Controllers
{
    public class perfil_empresaController : Controller
    {
        //
        // GET: /perfil_empresa/
        private BDMovilton bdo = new BDMovilton();

        public ActionResult Index()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return PartialView(bdo.perfil_empresa.ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        [HttpGet]
        public ActionResult EditEmpresa()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return View(bdo.perfil_empresa.ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult EditEmpresa(HttpPostedFileBase imagen, perfil_empresa perfil)
        {


            String path = Path.Combine(HttpContext.Server.MapPath("~/Images/Logos/"), perfil.logo);
            System.IO.File.Delete(path);
           
            String Nombre = System.IO.Path.GetRandomFileName();
            Nombre = System.IO.Path.ChangeExtension(Nombre, extension: "png");
            perfil.logo = Nombre;
            path = Path.Combine(Server.MapPath("~/Images/Logos"), Nombre);
            
            imagen.SaveAs(path);
            

            perfil.id_user = int.Parse(Session["LogedUserID"].ToString());
            bdo.Entry(perfil).State = EntityState.Modified;
            bdo.SaveChanges();
       
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }
        
    }
}
