using ApiErgoFit.DTOs;
using ApiErgoFit.Models;
using ApiErgoFit.Service.DepartamentoService;
using ApiErgoFit.Service.UsuarioMasterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiErgoFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class UsuarioMasterController : ControllerBase
    {

        private readonly IUsuarioMasterInterface _usuarioMasterInterface;

        public UsuarioMasterController(IUsuarioMasterInterface usuarioMasterInterface)
        {
            _usuarioMasterInterface = usuarioMasterInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UsuarioMasterModel>>>> GetUsuarios()
        {
            return Ok(await _usuarioMasterInterface.GetUsuarios());
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<DepartamentoModel>>> CriarUsuario([FromBody] CriarUsuarioMasterDto dto)
        {
            var resultado = await _usuarioMasterInterface.CriarUsuario(dto);
            return Ok(resultado); // Retorna UsuarioMasterModel na resposta
        }
    }
}
