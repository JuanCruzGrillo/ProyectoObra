using ProyectoObra.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoObra.Web.Models
{
    public partial class ContratacionProductoViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Contratacion")]
        public int ContratacionId { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        public Contratacion? Contratacion { get; set; }
        public  Producto? Producto { get; set; } 


        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Unidad { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public int Precio { get; set; }


        [Display(Name = "Activo")]
        public bool Activo { get; set; }
    }
}

