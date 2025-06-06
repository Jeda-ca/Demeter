﻿using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEstadoVentaRepository : IGenericRepository<EstadoVenta>
    {
        EstadoVenta GetByName(string name);
    }
}
