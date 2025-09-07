using ApiErgoFit.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiErgoFit.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }


        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set; }
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<SessaoModel> Sessao { get; set; }
        public DbSet<UsuarioMasterModel> UsuariosMaster { get; set; }
    }
}
