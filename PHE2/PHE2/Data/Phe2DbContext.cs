using PHE2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PHE2.Data
{
    public class Phe2DbContext : DbContext
    {
        public Phe2DbContext() : base("Phe2Context") { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.UserProjects)
                        .WithRequired(up => up.User)
                        .HasForeignKey(up => up.UserGuid)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasRequired(u => u.Account)
                        .WithRequiredPrincipal(a => a.User)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Account>()
                        .HasMany(a => a.AccountRoles)
                        .WithRequired(ar => ar.Account)
                        .HasForeignKey(ar => ar.AccountGuid)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Account>()
                        .HasRequired(a => a.Characteristic)
                        .WithRequiredPrincipal(c => c.Account)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Role>()
                        .HasMany(r => r.AccountRoles)
                        .WithRequired(ar => ar.Role)
                        .HasForeignKey(ar => ar.RoleGuid)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<Project>()
                        .HasMany(p => p.UserProjects)
                        .WithRequired(up => up.Project)
                        .HasForeignKey(up => up.ProjectGuid)
                        .WillCascadeOnDelete(false);
        }
    }
}