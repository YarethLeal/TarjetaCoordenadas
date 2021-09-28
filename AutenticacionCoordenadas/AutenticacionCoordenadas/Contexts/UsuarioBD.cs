using AutenticacionCoordenadas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticacionCoordenadas.Contexts
{
    public class UsuarioBD : DbContext
    {
        public UsuarioBD(DbContextOptions<UsuarioBD> options) : base(options)
        {

        }
        public DbSet<Usuario> tb_Usuario { get; set; }
    }
}
