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
    public class GraficsController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public GraficsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("barras")]
        public async Task<ActionResult<IEnumerable<GraficoBarras>>> GetBarras(Document document)
        {
            string StoredProc = "exec app.GRAFICA_BARRAS_X_ESTILISTA " +
                    "@DNI ='" + document.DNI + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.GraficoBarras.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost("tagcloud")]
        public async Task<ActionResult<IEnumerable<TagCloud>>> GetTagCloud(Document document)
        {
            string StoredProc = "exec app.TAG_CLOUD " +
                    "@DNI ='" + document.DNI + "'";

            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.TagCloud.FromSqlRaw(StoredProc).ToListAsync();
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
