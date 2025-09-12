using ApiErgoFit.DataContext;
//using ApiErgoFit.Interfaces;
using ApiErgoFit.Models;
using ApiErgoFit.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ApiErgoFit.Service.EmpresaService
{
    public class EmpresaService : IEmpresaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<EmpresaUsuarioModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmpresaService(ApplicationDbContext context, UserManager<EmpresaUsuarioModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceResponse<EmpresaModel>> CriarEmpresa(CriarEmpresaDto dto)
        {
            var serviceResponse = new ServiceResponse<EmpresaModel>();

            try
            {
                // Verifica se o CNPJ já existe como e-mail de um usuário
                var existingUser = await _userManager.FindByEmailAsync(dto.Cnpj);
                if (existingUser != null)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Já existe uma empresa cadastrada com este CNPJ.";
                    return serviceResponse;
                }

                // Cria o modelo de empresa
                var empresa = new EmpresaModel
                {
                    Nome = dto.Nome,
                    Cnpj = dto.Cnpj,
                    DataVencimento = dto.DataVencimento,
                    DataCriacao = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Ativo = true
                };

                // Cria o usuário de autenticação para a empresa
                var empresaUsuario = new EmpresaUsuarioModel
                {
                    UserName = dto.Cnpj,
                    Email = dto.Cnpj,
                    EmailConfirmed = true,
                    Empresa = empresa // Relaciona o usuário com a empresa
                };

                var result = await _userManager.CreateAsync(empresaUsuario, dto.Senha);

                if (!result.Succeeded)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Falha ao criar o usuário da empresa.";
                    return serviceResponse;
                }

                if (!await _roleManager.RoleExistsAsync("Empresa"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Empresa"));
                }
                await _userManager.AddToRoleAsync(empresaUsuario, "Empresa");

                serviceResponse.Dados = empresa;
                serviceResponse.Mensagem = "Empresa criada com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmpresaModel>>> GetEmpresas()
        {
            ServiceResponse<List<EmpresaModel>> serviceResponse = new ServiceResponse<List<EmpresaModel>>();

            try
            {
                serviceResponse.Dados = await _context.Empresas
                    .Include(e => e.Departamentos)
                    .Include(e => e.Funcionarios)
                    .ToListAsync();

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
