using AutenticacionCoordenadas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticacionCoordenadas.Contexts
{
    public class OficinaBD : DbContext
    {
        public OficinaBD(DbContextOptions<OficinaBD> options) : base(options) 
        {
        
        }
        public DbSet<Oficina> tb_Oficina { get; set; }
    }
}