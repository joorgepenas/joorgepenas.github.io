using apiBarberShop.Context;
using apiBarberShop.Models;
using apiBarberShop.Models.ResponseDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace apiBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public ResponseDTO _responseDTO;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // POST: api/outputs
        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount(Login login)
        {
            string StoredProc = "exec app.LOGIN_APP " +
                    "@CORREO = '" + login.CORREO + "'," +
                    "@CONTRASENA= '" + login.CONTRASENA + "'";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var usuarios = _context.MostrarUsu.FromSqlRaw(StoredProc).ToList().FirstOrDefault();
                if (usuarios != null )
                {
                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.CORREO));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    string bearer_token = tokenHandler.WriteToken(createdToken);
                    var token = new { access_Token = bearer_token, infouser = usuarios };
                    var response = _responseDTO.Success(_responseDTO, token);
                    return Ok(response);
                }
                else
                {
                    var response = _responseDTO.Success(_responseDTO, usuarios);
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<MostrarUsu>>> CreateUser(Registro registro)
        {
            string StoredProc = "exec app.USP_REGISTRAR2 " +
                    "@DNI = '" + registro.DNI + "'," +
                    "@APE_PAT = '" + registro.APE_PAT + "'," +
                    "@APE_MAT= '" + registro.APE_MAT + "'," +
                    "@NOMBRE= '" + registro.NOMBRE + "'," +
                    "@FECHA_NACIMIENTO= '" + registro.FECHA_NACIMIENTO + "'," +
                    "@CORREO= '" + registro.CORREO + "'," +
                    "@CONTRASENA= '" + registro.CONTRASENA + "'," +
                    "@ID_SEXO= " + registro.ID_SEXO + "";

            string StoredP = "exec app.USP_OBTENER_CO " +
                    "@CORREO= '" + registro.CORREO + "'";

            string StoredD = "exec app.USP_OBTENER " +
                    "@DNI= " + registro.DNI + "";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var exists = await _context.MostrarUsu.FromSqlRaw(StoredP).ToListAsync();
                var cantidad = exists.Count();
                var exists2 = await _context.MostrarUsu.FromSqlRaw(StoredD).ToListAsync();
                var cantidad2 = exists2.Count();
                if (cantidad == 0 && cantidad2 == 0)
                {
                    var usuarios = await _context.MostrarUsu.FromSqlRaw(StoredProc).ToListAsync();
                    var response = _responseDTO.Success(_responseDTO, usuarios);
                    return Ok(response);
                }
                else
                {


                    string e = "DNI o Correo existente.";
                    var response = _responseDTO.Valid(_responseDTO, e, 2);
                    return Ok(response);
                }

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

        // POST: api/outputs
        [HttpPost("forgetpassword")]
        public async Task<ActionResult<IEnumerable<ForgetUser>>> ForgetPassword(Email email)
        {
            string StoredProc = "exec app.CAMBIARPASS " +
                    "@CORREO = '" + email.CORREO + "'";

            string StoredP = "exec app.USP_OBTENER_CO " +
                    "@CORREO= '" + email.CORREO + "'";

            //return await _context.output.ToListAsync();
            _responseDTO = new ResponseDTO();
            try
            {
                var exists = await _context.MostrarUsu.FromSqlRaw(StoredP).ToListAsync();
                var cantidad = exists.Count();
                if (cantidad != 0)
                {
                    var usuarios = await _context.ForgetUser.FromSqlRaw(StoredProc).ToListAsync();
                    var response = _responseDTO.Success(_responseDTO, usuarios);
                    return Ok(response);
                }
                else
                {
                    string e = "Correo no existente.";
                    var response = _responseDTO.Valid(_responseDTO, e, 2);
                    return Ok(response);
                }

            }
            catch (Exception e)
            {
                var response = _responseDTO.Failed(_responseDTO, e);
                return BadRequest(response);
            }
        }

    }
}
