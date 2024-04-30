using ProyectoObra.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoObra.Application.Servicios
{
    internal class ManejadorServicios
    {

        private readonly AppDbContext _db;

        public ManejadorServicios(AppDbContext db)
        {
            _db = db;

        }
        
    }
}
