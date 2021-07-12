using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy.Models;

namespace CursoUdemy.Controllers
{
    public class BusController : Controller
    {
        public void listarModelo()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaModelo = lista;
            }
        }

        public void listarSucursal()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSucursal = lista;
            }
        }

        public void listarMarca()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaMarca = lista;
            }
        }

        public void listarTipoBus()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoBus = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoBus();
            listarModelo();
            listarMarca();
            listarSucursal();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oBusCLS);
            }

            using(var bd = new BDPasajeEntities1())
            {
                Bus oBus = new Bus();
                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.IIDTIPOBUS = oBusCLS.iidTipoBus;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROFILAS = oBusCLS.numeroFilas;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidMarca;
                oBus.BHABILITADO = 1;

                bd.Bus.Add(oBus);

                bd.SaveChanges();
          
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {

            BusCLS oBusClS = new BusCLS();
            listarCombos();
            using(var bd = new BDPasajeEntities1())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(id)).First();
                oBusClS.iidBus = oBus.IIDBUS;
                oBusClS.iidSucursal =(int) oBus.IIDSUCURSAL;
                oBusClS.iidTipoBus =(int) oBus.IIDTIPOBUS;
                oBusClS.placa = oBus.PLACA;
                oBusClS.fechaCompra =(DateTime) oBus.FECHACOMPRA;
                oBusClS.iidModelo =(int) oBus.IIDMODELO;
                oBusClS.numeroColumnas =(int) oBus.NUMEROCOLUMNAS;
                oBusClS.numeroFilas =(int) oBus.NUMEROFILAS;
                oBusClS.descripcion = oBus.DESCRIPCION;
                oBusClS.observacion = oBus.OBSERVACION;
                oBusClS.iidMarca =(int) oBus.IIDMARCA;
            }

            return View(oBusClS);
        }




        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using(var bd=new BDPasajeEntities1())
            {
                listaBus  =  (from bus in bd.Bus
                             join Sucursal in bd.Sucursal
                             on bus.IIDSUCURSAL equals Sucursal.IIDSUCURSAL
                             join TipoBus in bd.TipoBus
                             on bus.IIDTIPOBUS equals TipoBus.IIDTIPOBUS
                             join tipoModelo in bd.Modelo
                             on bus.IIDMODELO equals tipoModelo.IIDMODELO
                             where bus.BHABILITADO==1
                             select new BusCLS
                             {
                                 iidBus=bus.IIDBUS,
                                 placa=bus.PLACA,
                                 nombreModelo=tipoModelo.NOMBRE,
                                 nombreSucursal=Sucursal.NOMBRE,
                                 nombreTipoBus=TipoBus.NOMBRE
                             }).ToList();
            }


            return View(listaBus);
        }
    }
}