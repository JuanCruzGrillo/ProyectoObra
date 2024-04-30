using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class Contratacion
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string? Descripcion { get; set; }
        public int? idEmpresa { get; set; }

        [ForeignKey("idEmpresa")]
        public virtual Empresa Empresa { get; set; } = null!;

        public DateTime FechaInicio{ get; set; }

        public bool Activo { get; set; }
        public bool Finalizado { get; set; }
    }
}