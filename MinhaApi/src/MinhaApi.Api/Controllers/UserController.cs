using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MinhaApi.Domain.Entities;
using MinhaApi.Application.Interfaces;
using MinhaApi.Application.DTOs.User;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
// using Microsoft.IdentityModel.JsonWebTokens;

namespace MinhaApi.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("sing-up")]
        public async Task<ActionResult<User>> Create(SignUpDTO dto)
        {
            var user = await _service.SignUp(dto);

            if (user != null)
            {
                return Unauthorized(new { message = "Usuário indisponível" });
            }

            return Ok(user);
        }

        [HttpPost("sing-in")]
        public async Task<IActionResult> Login(SingInDTO dto)
        {
            var token = await _service.SignIn(dto.UserName, dto.Password);

            if (token == null) return Unauthorized();

            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("auth")]
        public async Task<ActionResult<User>> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new InvalidOperationException("Token INvalida.");
            }

            int id = int.Parse(userId);

            var user = await _service.GetById(id);

            return Ok(user);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAll()
        {
            return await _service.GetAll();
        }

        [Authorize(Policy = "SameUserOrAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            var user = await _service.GetById(id);

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return user;
        }

        [Authorize(Policy = "SameUserOrAdmin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDTO updatedUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Update(id, updatedUser);

            if (!result)
                return NotFound(new { message = "Usuário não encontrado." });

            return Ok(new { message = "Usuário atualizado com sucesso." });
        }

        [Authorize(Policy = "SameUserOrAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Remove(id);

            if (!result) return NotFound(new { message = "Usuário não encontrado." });

            return Ok(new { message = "Usuário removido com sucesso." });
        }
    }
}