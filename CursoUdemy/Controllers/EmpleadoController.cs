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
                                     nombreTipoUsuario = TipoUsuario.NOMBRE,
                                     nombreTipoContrato = TipoContrato.NOMBRE
                                 }).ToList();


            }
            return View(listaEmpleado);
        }
    }
}