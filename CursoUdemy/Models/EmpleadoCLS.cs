using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoUdemy.Models
{
    public class EmpleadoCLS
    {

        [Display(Name ="ID Empleado")]
        public int iidEmpleado { get; set; }

        [Display(Name ="Nombre")]
        [Required]
        [StringLength(100, ErrorMessage ="Longitud Maxima 100")]
        public string nombre { get; set; }

        [Required]
        [Display(Name ="Apellido Paterno")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string apPaterno { get; set; }

        [Required]
        [Display(Name ="Apellido Materno")]
        [StringLength(200, ErrorMessage = "Longitud Maxima 200")]
        public string apMaterno { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name ="fecha Contrado")]
        public DateTime fechaContrato { get; set; }

        [Required]
        [Display(Name ="Tipo Usuario")]
        public int iidtipoUsuario { get; set; }


        [Display(Name ="Sueldo")]
        [Required]
        public decimal sueldo { get; set; }

        [Required]
        [Display(Name ="Tipo Contrato")]
        public int iidtipoContrato { get; set; }

        [Required]
        [Display(Name ="Sexo")]
        public int iidSexo { get; set; }

        public int bhabilitado { get; set; }




        ///Propiedades adicionales
        
        [Display(Name ="Tipo Contrato")]
        public string nombreTipoContrato { get; set; }

        [Display(Name ="Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }

    }
}