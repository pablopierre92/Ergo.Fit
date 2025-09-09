using ApiErgoFit.DataContext;
using ApiErgoFit.DTOs;
using ApiErgoFit.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiErgoFit.Service.UsuarioMasterService
{
    public class UsuarioMasterService : IUsuarioMasterInterface
    {
        private readonly ApplicationDbContext _context;
        public UsuarioMasterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<UsuarioMasterModel>> CriarUsuario(CriarUsuarioMasterDto dto)
        {
            // Converte DTO para Model
            var usuario = new UsuarioMasterModel
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,

            };

            // Salva no banco usando UsuarioMasterModel
            _context.UsuariosMaster.Add(usuario);
            await _context.SaveChangesAsync();

            return new ServiceResponse<UsuarioMasterModel> { Dados = usuario };
        }

        public async Task<ServiceResponse<List<UsuarioMasterModel>>> GetUsuarios()
        {
            ServiceResponse<List<UsuarioMasterModel>> serviceResponse = new ServiceResponse<List<UsuarioMasterModel>>();

            try
            {
                serviceResponse.Dados = _context.UsuariosMaster.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }



            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        
    }
}
