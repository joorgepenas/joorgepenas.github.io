using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiBarberShop.Context;
using apiBarberShop.Models;
using apiBarberShop.Models.ResponseDTO;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace apiBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> Getusuario()
        {
            string StoredProc = "exec app.usp_listar ";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        // POST: api/outputs
        [HttpGet("{dni}")]
        public async Task<ActionResult<IEnumerable<MostrarUsu2>>> InfoUser(string dni)
        {
            string StoredProc = "exec app.USP_OBTENER " +
                    "@DNI = '" + dni + "'";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                    var usuarios = await _context.MostrarUsu2.FromSqlRaw(StoredProc).ToListAsync();
                    var response = _responseDTO.Success(_responseDTO, usuarios);
                    return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("correo/{correo}")]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> InfoCorreo(string correo)
        {
            string StoredProc = "exec app.SEARCH_EMAIL " +
                    "@CORREO2 = '" + correo + "'";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("list/worker")]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> GetWorkers()
        {
            string StoredProc = "exec app.LISTAR_ESTILISTAS ";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }



        // POST: api/outputs
        [HttpPut]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> ChangeInfo(ChangeInfo info)
        {
            string StoredProc = "exec app.CAMBIARPASSUSU " +
                    "@DNI = '" + info.DNI + "'," +
                    "@APE_PAT = '" + info.APE_PAT + "'," +
                    "@APE_MAT= '" + info.APE_MAT + "'," +
                    "@NOMBRE= '" + info.NOMBRE + "'," +
                    "@FECHA_NACIMIENTO= '" + info.FECHA_NACIMIENTO + "'," +
                    "@CONTRASENA= '" + info.CONTRASENA + "'," +
                    "@ID_SEXO= " + info.ID_SEXO + "";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                    var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                    var response = _responseDTO.Success(_responseDTO, usuarios);
                    return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPut("admin")]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> ChangeInfoUserAdmin(ChangeInfo2 info)
        {
            string StoredProc = "";

            if (info.ID_CATE == null)
            {
                StoredProc = "exec app.UPDATE_USU_ADM " +
                    "@DNI = '" + info.DNI + "'," +
                    "@APE_PAT = '" + info.APE_PAT + "'," +
                    "@APE_MAT= '" + info.APE_MAT + "'," +
                    "@NOMBRE= '" + info.NOMBRE + "'," +
                    "@FECHA_NACIMIENTO= '" + info.FECHA_NACIMIENTO + "'," +
                    "@CORREO= '" + info.CORREO + "'," +
                    "@ID_SEXO= " + info.ID_SEXO + "," +
                    "@ID_ROL= " + info.ID_ROL + "," +
                    "@ID_CATE= " + System.Data.SqlTypes.SqlInt32.Null + "";
            }
            else
            {
                StoredProc = "exec app.UPDATE_USU_ADM " +
                    "@DNI = '" + info.DNI + "'," +
                    "@APE_PAT = '" + info.APE_PAT + "'," +
                    "@APE_MAT= '" + info.APE_MAT + "'," +
                    "@NOMBRE= '" + info.NOMBRE + "'," +
                    "@FECHA_NACIMIENTO= '" + info.FECHA_NACIMIENTO + "'," +
                    "@CORREO= '" + info.CORREO + "'," +
                    "@ID_SEXO= " + info.ID_SEXO + "," +
                    "@ID_ROL= " + info.ID_ROL + "," +
                    "@ID_CATE= " + info.ID_CATE + "";
            }
            

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        private bool UsuarioExists(string id)
        {
            return _context.Usuario.Any(e => e.DNI == id);
        }
    }
}
