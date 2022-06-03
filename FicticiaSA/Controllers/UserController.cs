using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FicticiaSA.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registro")] //User Register
        public async Task<ActionResult> Register([FromForm]UserDto userDto)
        {
            try
            {
                await _userService.Register(userDto);
                return Ok($"Usuario con nombre: {userDto.UserName} fue creado exitosamente.");
            }
            catch (DuplicateNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPost("Login")] //User Login
        public async Task<ActionResult<string>> Login([FromForm]UserDto userDto)
        {
            try
            {
                return Ok(await _userService.Login(userDto));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
