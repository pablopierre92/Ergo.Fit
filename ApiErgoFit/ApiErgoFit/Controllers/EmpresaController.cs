using ApiErgoFit.DTOs;
using ApiErgoFit.Models;
using ApiErgoFit.Service.EmpresaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ApiErgoFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaInterface _empresaInterface;

        public EmpresaController(IEmpresaInterface empresaInterface)
        {
            _empresaInterface = empresaInterface;
        }

        [HttpGet]
        [Authorize(Roles = "Master")]
        public async Task<ActionResult<ServiceResponse<List<EmpresaModel>>>> GetEmpresas()
        {
            return Ok(await _empresaInterface.GetEmpresas());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<EmpresaModel>>> CriarEmpresa([FromBody] CriarEmpresaDto dto)
        {
            var resultado = await _empresaInterface.CriarEmpresa(dto);
            return Ok(resultado);
        }
    }
}
