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
    public class BackupController : ControllerBase
    {
        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;

        public BackupController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Backup>>> Backup()
        {
            string StoredProc = "exec app.BACKUP_APP ";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Backup.FromSqlRaw(StoredProc).ToListAsync();
                var response = _responseDTO.Success(_responseDTO, usuarios);
                return Ok(response);

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpGet("last")]
        public async Task<ActionResult<IEnumerable<Backup>>> GetBackup()
        {
            string StoredProc = "exec app.TRES_ULT_BKP ";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = await _context.Backup.FromSqlRaw(StoredProc).ToListAsync();
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
