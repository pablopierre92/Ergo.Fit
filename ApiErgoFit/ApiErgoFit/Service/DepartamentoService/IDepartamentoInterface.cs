using ApiErgoFit.DTOs;
using ApiErgoFit.Models;

namespace ApiErgoFit.Service.DepartamentoService
{
    public interface IDepartamentoInterface
    {
        Task<ServiceResponse<List<DepartamentoModel>>> GetDepartamentos();

        Task<ServiceResponse<DepartamentoModel>> CriarDepartamento(CriarDepartamentoDto dto);

    }
}
