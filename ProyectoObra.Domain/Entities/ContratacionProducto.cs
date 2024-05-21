using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class ContratacionProducto
    {
        public int Id { get; set; }
        [MinLength(3)]
        public int? ContratacionId { get; set; }

        [ForeignKey("ContratacionId")]
        public virtual Contratacion Contratacion{ get; set; } = null!;
        public int? ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; } = null!;

        public int Unidad { get; set; }
        public int Precio { get; set; }

        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }
}