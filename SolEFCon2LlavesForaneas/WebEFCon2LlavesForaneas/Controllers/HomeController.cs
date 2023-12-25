using BusinessTienda;
using DataTienda.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEFCon2LlavesForaneas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BusProductos bus = new BusProductos();
        BusMarcas busM = new BusMarcas();
        BusDepartamento busD = new BusDepartamento();
        public ActionResult Index()
        {
            try
            {
                List<Productos> ls = bus.Obtener();
                return View("Consulta",ls);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Buscar(string valor)
        {
            try
            {
                List<Productos> ls = bus.Buscar(valor);
                return View("Consulta", ls);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: Home/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }*/

        // GET: Home/Create
        public ActionResult Create()
        {
            List<Departamentos> lsD = busD.Obtener();
            List<Marcas> lsM = busM.Obtener();
            
            ViewBag.Marcaid = new SelectList(lsM, "idM", "NombreM");
            ViewBag.Departamentoid = new SelectList(lsD, "idD", "NombreD");

            return View("");
        }

        // POST: Home/Create
        //[HttpPost]
        public ActionResult CreateBD(Productos p)
        {
            try
            {
                bus.ValidaProductoMarcaRepetido(p);
                bus.Agregar(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msj"] = ex.Message;
                List<Departamentos> lsD = busD.Obtener();
                List<Marcas> lsM = busM.Obtener();

                ViewBag.Marcaid = new SelectList(lsM, "idM", "NombreM");
                ViewBag.Departamentoid = new SelectList(lsD, "idD", "NombreD");
                return View("Create");
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Productos p = bus.Obtener(id);
                List<Departamentos> lsD = busD.Obtener();
                List<Marcas> lsM = busM.Obtener();

                ViewBag.Marcaid = new SelectList(lsM, "idM", "NombreM", p.Marcaid);
                ViewBag.Departamentoid = new SelectList(lsD, "idD", "NombreD", p.Departamentoid);
                return View(p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Productos p)
        {
            try
            {
                bus.Editar(p);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: Home/Delete/5
        //[HttpPost]
        public ActionResult Delete(Productos p)
        {
            try
            {
                // TODO: Add delete logic here
                bus.Borrar(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
