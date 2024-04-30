using System.ComponentModel.DataAnnotations;

namespace ProyectoObra.Web.Models
{
    public partial class ContratacionViewModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;
        [Required]
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime FechaInicio { get; set; }
    }
}
