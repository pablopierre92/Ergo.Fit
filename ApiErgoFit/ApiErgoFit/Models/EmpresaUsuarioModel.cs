using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ApiErgoFit.Models
{
    public class EmpresaUsuarioModel : IdentityUser
    {
        // Chave Estrangeira para o EmpresaModel (relação 1-para-1)
        public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual EmpresaModel? Empresa { get; set; }

    }
}
