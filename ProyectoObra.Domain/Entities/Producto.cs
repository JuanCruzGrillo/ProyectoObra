using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int? CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; } = null!;
        public int? RubroId { get; set; }

        [ForeignKey("RubroId")]
        public virtual Rubro Rubro { get; set; } = null!;


    }
}