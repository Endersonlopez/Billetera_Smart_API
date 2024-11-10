using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Billetera_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClsEstadosController : ControllerBase
    {
        private readonly CN_ClsEStados _CNClsEstados;
        CE_ClsEstados CE_ClsEstados = new CE_ClsEstados();
        public ClsEstadosController(IConfiguration configuration)
        {
            _CNClsEstados = new CN_ClsEStados(configuration);
        }
        [HttpGet ("GetEstados")]
        public ActionResult<List<CE_ClsEstados>> ListarEstados(CE_ClsEstados obj)
        {
            try
            {
                var Resultado = _CNClsEstados.CN_Listar_Estados(obj);
                if (Resultado.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(Resultado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost ("PostEstados")]
        public ActionResult InsertarEstados([FromBody] Billetera_Smart.Models.AM_Estados _AMEstados)
        {            
            CE_ClsEstados.Estado = _AMEstados.Estado;
            CE_ClsEstados.Fecha_Creacion = _AMEstados.Fecha_Creacion;
            CE_ClsEstados.Fecha_Modificacion = _AMEstados.Fecha_Modificacion;
            CE_ClsEstados.Activo = _AMEstados.Activo;

            try
            {
                _CNClsEstados.CN_Insertar_Estados(CE_ClsEstados);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutEstados")]
        public ActionResult ActualizarEstados([FromBody] Billetera_Smart.Models.AM_Estados _AMEstados)
        {
            CE_ClsEstados.Id_Estado = _AMEstados.Id_Estado;
            CE_ClsEstados.Estado = _AMEstados.Estado;
            CE_ClsEstados.Fecha_Creacion = _AMEstados.Fecha_Creacion;
            CE_ClsEstados.Fecha_Modificacion = _AMEstados.Fecha_Modificacion;
            CE_ClsEstados.Activo = _AMEstados.Activo;

            try
            {
                _CNClsEstados.CN_Actualizar_Estados(CE_ClsEstados);
                return Ok("Actualizado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
