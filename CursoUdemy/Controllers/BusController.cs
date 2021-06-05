﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy.Models;

namespace CursoUdemy.Controllers
{
    public class BusController : Controller
    {
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