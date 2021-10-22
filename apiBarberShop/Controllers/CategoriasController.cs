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
    public class CategoriasController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
        {
            string StoredProc = "exec app.CAT ";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Categorias.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("servicios/{categoria}")]
        public async Task<ActionResult<IEnumerable<Servicios>>> GetServicios(string categoria)
        {
            string StoredProc = "exec app.SER " +
                    "@CATE =" + categoria;

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Servicios.FromSqlRaw(StoredProc).ToListAsync();
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
