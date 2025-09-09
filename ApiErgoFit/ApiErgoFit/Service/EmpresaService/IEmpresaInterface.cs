using ApiErgoFit.DTOs;
using ApiErgoFit.Models;

namespace ApiErgoFit.Service.EmpresaService
{
    public interface IEmpresaInterface
    {
        Task<ServiceResponse<List<EmpresaModel>>> GetEmpresas();

        Task<ServiceResponse<EmpresaModel>> CriarEmpresa(CriarEmpresaDto dto);
    }
}
