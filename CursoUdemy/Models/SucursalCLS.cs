using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoUdemy.Models
{
    public class SucursalCLS
    {
        [Display(Name ="Id Sucursal")]
        public int iidsucursal { get; set; }
        [Display(Name ="Nombre Sucursal")]
        [StringLength(100,ErrorMessage ="Longitud Maxima 100")]
        [Required]
        public string nombre { get; set; }
        [Display(Name ="Direccion")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        [Required]
        public string direccion { get; set; }
        [Display(Name ="Telefono")]
        [StringLength(10, ErrorMessage = "Longitud Maxima 10")]
        [Required]
        public string telefono { get; set; }
        [Display(Name ="Email Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud Maxima 100")]
        [Required]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        public string email { get; set; }
        [Display(Name ="Fecha Apertura")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime fechaApertura { get; set; }
        public int bhabilitado { get; set; }


    }
}