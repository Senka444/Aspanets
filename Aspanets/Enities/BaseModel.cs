using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Aspanets.Enities
{
    public partial class BaseModel : DbContext
    {
        public BaseModel()
            : base("name=BaseModel")
        {
        }

        public virtual DbSet<Aims> Aims { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aims>()
                .HasMany(e => e.Application)
                .WithOptional(e => e.Aims)
                .HasForeignKey(e => e.Aim);

            modelBuilder.Entity<Application>()
                .Property(e => e.Desctiption)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Staff)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.IsDepartment);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Application)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.Whom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Application)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.IdStatus);

            modelBuilder.Entity<Subdivision>()
                .HasMany(e => e.Staff)
                .WithOptional(e => e.Subdivision)
                .HasForeignKey(e => e.IsSubdivision);

            modelBuilder.Entity<Visitor>()
                .HasMany(e => e.Application)
                .WithRequired(e => e.Visitor)
                .HasForeignKey(e => e.IdVisitor)
                .WillCascadeOnDelete(false);
        }
    }
}
