using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class Rubro
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string? Descripcion { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; } = null!;
    }
}