using AutenticacionCoordenadas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticacionCoordenadas.Contexts
{
    public class BDContexts : DbContext
    {
        public BDContexts(DbContextOptions<BDContexts> options) : base(options) 
        {
        
        }
        public DbSet<Oficina> tb_Oficina { get; set; }
        public DbSet<Usuario> tb_Usuario { get; set; }
    }
}