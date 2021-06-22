using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy.Models;

namespace CursoUdemy.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {

            List<ClienteCLS> listaCliente = null;
            using(var bd=new BDPasajeEntities1())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    apPaterno = cliente.APPATERNO,
                                    apMaterno = cliente.APMATERNO,
                                    email = cliente.EMAIL,
                                    telefonoCelular = cliente.TELEFONOCELULAR
                                }).ToList();
            }
            return View(listaCliente);
        }


        List<SelectListItem> listaSexo;

        private void llenarSexo()
        {
            using(var bd=new BDPasajeEntities1())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Selecccione--", Value = "" });

            }
        }
        public ActionResult Agregar()
        {

            llenarSexo();
            ViewBag.lista = listaSexo;

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {

            if(!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }

            using(var bd=new BDPasajeEntities1())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.apPaterno;
                oCliente.APMATERNO = oClienteCLS.apMaterno;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonoCelular;
                oCliente.BHABILITADO = 1;
                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
            }

            return RedirectToAction("Index");

        }


    }
}