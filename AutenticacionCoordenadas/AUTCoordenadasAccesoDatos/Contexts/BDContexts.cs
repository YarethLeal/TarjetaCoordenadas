using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AUTCoordenadasAccesoADatos.Contexts
{
    public partial class BDContexts : DbContext
    {
        public virtual DbSet<Oficina> tb_Oficina { get; set; }
        public virtual DbSet<Usuario> tb_Usuario { get; set; }
        public BDContexts() 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Data Source=163.178.107.10;Initial Catalog=Sistema_DobleAutenticacion;Persist Security Info=True;User ID=laboratorios;Password=KmZpo.2796;Pooling=False");
        }
    }
}