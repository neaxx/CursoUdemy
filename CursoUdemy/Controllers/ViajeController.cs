using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy.Models;

namespace CursoUdemy.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje

        public void listarLugar()
        {
            //Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Lugar
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDLUGAR.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listarLugar = lista; //ViewBag es para castear(Lanzar) la lista
            }
        }

        //ActionResult devuelve la vista agregar con los comboBox listados
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        //Funcion ActionResult que devuelve la vista Index de Viaje con la informacion
        public ActionResult Index()
        {
            List<ViajeCLS> listaViaje = null;
            using (var bd = new BDPasajeEntities1())
            {
                listaViaje = (from viaje in bd.Viaje
                              join lugarOrigen in bd.Lugar
                              on viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR
                              join lugarDestino in bd.Lugar
                              on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                              join bus in bd.Bus
                              on viaje.IIDBUS equals bus.IIDBUS
                              select new ViajeCLS
                              {
                                  iidViaje = viaje.IIDVIAJE,
                                  nombreBus = bus.PLACA,
                                  nombreLugarOrigen = lugarOrigen.NOMBRE,
                                  nombreLugarDestino = lugarDestino.NOMBRE,

                              }).ToList();
            }

                return View(listaViaje);
        }

        public void listarBus()
        {
            //Agregar
            //Metodo para llenar ComboBox en Agregar

            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities1())
            {
                lista = (from item in bd.Bus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.PLACA,
                             Value = item.IIDBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listarBus = lista;
            }
        }


        public void listarCombos()
        {
            listarLugar();
            listarBus();
        }

    }
}