using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoUdemy.Models
{
    public class ClienteCLS
    {
        [Display(Name ="Id Cliente")]
        public int iidcliente { get; set; }
        [Display(Name ="Nombre")]
        [Required]
        [StringLength(100,ErrorMessage ="Longitud maxima 100")]
        public string nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        public string apPaterno { get; set; }
        [Display(Name ="Apellido Materno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        public string apMaterno { get; set; }
        [Display(Name ="Email")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        public string email { get; set; }

        [Required]
        [Display(Name ="Sexo")]
        public int iidsexo { get; set; }

        [Display(Name ="Telefono Celular")]
        [Required]
        public string telefonoCelular { get; set; }
        public int bhabilitado { get; set; }

    }
}