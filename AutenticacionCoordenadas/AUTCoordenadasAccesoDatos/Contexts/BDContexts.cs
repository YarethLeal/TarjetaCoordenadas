using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;



namespace AUTCoordenadasAccesoADatos.Contexts
{
    public partial class BDContexts :DbContext
    {
        public BDContexts() 
            : base("name=BDContexts")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<Oficina> tb_Oficina { get; set; }
        public virtual DbSet<Usuario> tb_Usuario { get; set; }
    }
}