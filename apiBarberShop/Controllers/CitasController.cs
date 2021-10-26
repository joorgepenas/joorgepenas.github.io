using apiBarberShop.Context;
using apiBarberShop.Models;
using apiBarberShop.Models.ResponseDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CitasController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public CitasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{dni}")]
        public async Task<ActionResult<IEnumerable<ServiciosUsuario>>> GetServiciosDNI(string dni)
        {
            string StoredProc = "exec app.DATA_ANAL " +
                    "@DNI ='" + dni + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.ServiciosUsuario.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("usuario/{dni}")]
        public async Task<ActionResult<IEnumerable<HistorialCitas>>> GetCitasDNI(string dni)
        {
            string StoredProc = "exec app.CITAS_CLIENTE " +
                    "@DNI ='" + dni + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.HistorialCitas.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("estilista/{dni}")]
        public async Task<ActionResult<IEnumerable<CitasEstilista>>> GetCitasDNIEstilista(string dni)
        {
            string StoredProc = "exec app.CITAS_ESTILISTA " +
                    "@DNI ='" + dni + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.CitasEstilista.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<IEnumerable<ReservaCita>>> PutEstadoCita(IdCita cita)
        {
            string StoredProc = "exec app.UPDATE_CITA " +
                    "@ID_CITA =" + cita.ID_CITA + "";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.ReservaCita.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut("cancel")]
        public async Task<ActionResult<IEnumerable<CancelarCita>>> PutCancelCita(IdCita cita)
        {
            string StoredProc = "exec app.UPDATE_CITA_USU " +
                    "@ID_CITA =" + cita.ID_CITA + "";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.CancelarCita.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut("modify")]
        public async Task<ActionResult<IEnumerable<CancelarCita>>> PutModifyCita(ModifyCita cita)
        {
            string StoredProc = "exec app.MODIFICAR_CITA " +
                    "@ID_CITA =" + cita.ID + "," +
                    "@FECHA_ATENCION = '" + Convert.ToDateTime(cita.FECHA) + "'," +
                    "@HORA = '" + cita.HORA + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.CancelarCita.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("feedback/{dni}")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback(string dni)
        {
            string StoredProc = "exec app.COMENTA " +
                    "@DNI ='" + dni + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Feedback.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("feedback/promedio/{dni}")]
        public async Task<ActionResult<IEnumerable<FeedbackPromedio>>> GetFeedbackPromedio(string dni)
        {
            string StoredProc = "exec app.PROMEDIO_ESTILISTA " +
                    "@DNI ='" + dni + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.FeedbackPromedio.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("validacion/hora")]
        public async Task<ActionResult<IEnumerable<HoraValidacion>>> GetHorario()
        {
            string StoredProc = "exec app.VALIDA_HORA ";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.HoraValidacion.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ReservaCita>>> SendReserva(Citas citas)
        {
            string StoredProc = "exec app.RESERVA_CITA " +
                    "@DNI = '" + citas.DNI + "'," +
                    "@DNI_ESTI = '" + citas.DNI2 + "'," +
                    "@FECHA_ATEN= '" + Convert.ToDateTime(citas.FECHA_ATENCION) + "'," +
                    "@HORA= '" + citas.HORA_RESERVACION + "'," +
                    "@ID_CATEGORIA_PAGO= '" + citas.ID_PAGO + "'," +
                    "@ID_SERVI= " + citas.ID_SERVICO + "";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.ReservaCita.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost("feedback")]
        public async Task<ActionResult<IEnumerable<SendFeed>>> SendFeedback(SendFeed feed)
        {
            string StoredProc = "exec app.FEED " +
                    "@ID_CITA = " + feed.ID_CITA + "," +
                    "@PUNTUACION = " + feed.PUNTUACION + "," +
                    "@COMENTARIO= '" + feed.COMENTARIO + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.SendFeed.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost("available")]
        public async Task<ActionResult<IEnumerable<CitasCliente>>> GetAvailable(DataDisponibilidad data)
        {
            string StoredProc = "exec app.VALIDAR_DISPONIBILIDAD " +
                    "@DNI = '" + data.DNI + "'," +
                    "@FECHA_ATENCION = '" + Convert.ToDateTime(data.FECHA) + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.CitasCliente.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }
    }
}
