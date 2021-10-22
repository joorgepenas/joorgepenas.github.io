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
    public class EstilistasController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public EstilistasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Estilistas>>> GetEstilistas(string id)
        {
            string StoredProc = "exec app.USUARIO_CATE " +
                    "@CATE =" + id;

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Estilistas.FromSqlRaw(StoredProc).ToListAsync();
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
