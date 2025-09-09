using ApiErgoFit.DTOs;
using ApiErgoFit.Models;

namespace ApiErgoFit.Service.UsuarioMasterService
{
    public interface IUsuarioMasterInterface
    {
        Task<ServiceResponse<List<UsuarioMasterModel>>> GetUsuarios();

        Task<ServiceResponse<UsuarioMasterModel>> CriarUsuario(CriarUsuarioMasterDto dto);
    }
}
