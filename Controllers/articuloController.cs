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
    public class articuloController : Controller
    {
        //
        // GET: /articulo/

        private BDMovilton bdo = new BDMovilton();
        

        public ActionResult Index()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return PartialView(bdo.articulos.ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        public ActionResult CreateArticle()
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return View();
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        [HttpGet]
        public ActionResult EditArticle(int id)
        {
            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return View(bdo.articulos.Where(articulo => articulo.id_articulo == id).ToList());
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
            
        }

        public ActionResult DeleteArticle()
        {

            if (Session["LogedUserID"] != null && Session["LogedUserFullName"] != null && Session["LogedUserType"] != null)
            {
                var lista = bdo.perfil_empresa.First();
                ViewBag.img = lista.logo;
                return View();
            }
            else
            {
                return RedirectToAction("LoginError", "Home");
            }
        }


        [HttpPost]
        public ActionResult InsertArticule(HttpPostedFileBase imagen, articulos articulo)
        {

            String Nombre = System.IO.Path.GetRandomFileName();
            Nombre = System.IO.Path.ChangeExtension(Nombre, extension: "png");
            articulo.imagen = Nombre;

            String path = Path.Combine(Server.MapPath("~/Images/Articulos"), Nombre);
            imagen.SaveAs(path);


            articulo.id_user= int.Parse(Session["LogedUserID"].ToString());
            bdo.articulos.Add(articulo);
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


        [HttpPost]
        public ActionResult UpdateArticle(HttpPostedFileBase image, articulos art)
        {
            if (ModelState.IsValid)
            {
                using (BDMovilton dc = new BDMovilton())
                {


                    String path = Path.Combine(HttpContext.Server.MapPath("~/Images/Articulos/"), art.imagen);
                    System.IO.File.Delete(path);

                    String Nombre = System.IO.Path.GetRandomFileName();
                    Nombre = System.IO.Path.ChangeExtension(Nombre, extension: "png");
                    art.imagen = Nombre;
                    path = Path.Combine(Server.MapPath("~/Images/Articulos"), Nombre);

                    if (image != null)
                    { 
                        image.SaveAs(path);
                    }
                    art.id_user = int.Parse(Session["LogedUserID"].ToString()); 
                    dc.Entry(art).State = EntityState.Modified;
                    dc.SaveChanges();
                  
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
