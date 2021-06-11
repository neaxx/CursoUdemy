using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy.Models;

namespace CursoUdemy.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd = new BDPasajeEntities1())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join TipoUsuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals TipoUsuario.IIDTIPOUSUARIO
                                 join TipoContrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals TipoContrato.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO==1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     apPaterno = empleado.APPATERNO,
                                     apMaterno = empleado.APMATERNO,
                                     nombreTipoUsuario = TipoUsuario.NOMBRE,
                                       //sueldo
                                     nombreTipoContrato = TipoContrato.NOMBRE
                                 }).ToList();


            }
            return View(listaEmpleado);
        }


        public void listarComboSexo()
        {
            //Agregar

            List<SelectListItem> lista;
            using(var bd = new BDPasajeEntities1())
            {
                lista = (from sexo in bd.Sexo
                         where sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = sexo.NOMBRE,
                             Value = sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSexo = lista;
            }
        }


        public void listarTipoContrado()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from TipoContrato in bd.TipoContrato
                         where TipoContrato.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = TipoContrato.NOMBRE,
                             Value = TipoContrato.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoContrato = lista;
            }
        }

        public void listarTipoUsuario()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from TipoUsuario in bd.TipoUsuario
                         where TipoUsuario.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = TipoUsuario.NOMBRE,
                             Value = TipoUsuario.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoUsuario = lista;
            }
        }


        public void listarCombos()
        {
            listarTipoUsuario();
            listarTipoContrado();
            listarComboSexo();
        }



        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oEmpleadoCLS);
            }
            using (var bd = new BDPasajeEntities1())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                oEmpleado.APPATERNO = oEmpleadoCLS.apPaterno;
                oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidtipoUsuario;
                oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidtipoContrato;
                oEmpleado.IIDSEXO = oEmpleado.IIDSEXO;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();

            }

            return RedirectToAction("Index");
        }


    }
}