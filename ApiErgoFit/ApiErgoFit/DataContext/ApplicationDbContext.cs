using ApiErgoFit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiErgoFit.DataContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioMasterModel> UsuariosMaster { get; set; }
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<EmpresaUsuarioModel> EmpresasUsuarios { get; set; }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
