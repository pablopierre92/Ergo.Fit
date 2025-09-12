using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApiErgoFit.Models
{

    // A classe agora herda de IdentityUser para integração com o ASP.NET Core Identity
    public class UsuarioMasterModel : IdentityUser
    {
        // O Id, Email e Senha agora são gerenciados pela classe base IdentityUser.

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;

        // Relacionamento com EmpresaModel. O Id agora será o Id do IdentityUser.
        public virtual ICollection<EmpresaModel> EmpresasCriadas { get; set; } = new List<EmpresaModel>();
    }

    /*public class UsuarioMasterModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Senha { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;

        // Relacionamentos
        public virtual ICollection<EmpresaModel> EmpresasCriadas { get; set; } = new List<EmpresaModel>();


    }*/
}
