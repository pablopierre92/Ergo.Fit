using ApiErgoFit.DTOs;
using ApiErgoFit.Models;

namespace ApiErgoFit.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        Task<ServiceResponse<FuncionarioModel>> CriarFuncionario(CriarFuncionarioDto dto);

        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario);

        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);


    }
}
