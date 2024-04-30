using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string? Descripcion { get; set; }

    }
}