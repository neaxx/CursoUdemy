using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoUdemy.Models
{
    public class ViajeCLS
    {
        [Display(Name ="ID Viaje")]
        public int iidViaje { get; set; }

        [Required]
        [Display(Name = "Lugar Origen")]
        public int iidLugarOrigen { get; set; }

        [Required]
        [Display(Name = "Lugar Destino")]
        public int iidLugarDestino { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double precio { get; set; }

        [Required]
        [Display(Name = "Fecha Viaje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime fechaViaje { get; set; }

        [Required]
        [Display(Name = "Numero Asientos Disponibles")]
        public int numeroAsientosDisponibles { get; set; }

        //Porpiedades adicionales

        [Display(Name ="Lugar Orgien")]
        public string nombreLugarOrigen { get; set; }
        [Display(Name = "Lugar Destino")]
        public string nombreLugarDestino { get; set; }
        [Display(Name = "Nombre Bus")]
        public string nombreBus { get; set; }


    }
}