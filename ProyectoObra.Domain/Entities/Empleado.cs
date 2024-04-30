using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Domain.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string? FullName { get; set; }
        public int Age { get; set; }
        public int EmpresaId { get; set; }
        public virtual  Empresa Empresa { get; set; } = null!;

    }
}