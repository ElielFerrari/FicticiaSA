using BusinessLogic.Dto;
using BusinessLogic.Mapper;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration  _configuration;

        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task Register(UserDto userDto)
        {
            if(!_context.Users.Any(x => x.Username == userDto.UserName))
            {
                
                CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var user = UserMapper.MapToUser(userDto, passwordHash, passwordSalt);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateNameException("El usuario con ese nombre ya existe.");
            }
        }
        
        public async Task<string> Login(UserDto userDto)
        {
            var user = await (from u in _context.Users
                              where u.Username == userDto.UserName
                              select u).FirstOrDefaultAsync();

            if ((user == null) && (!VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt)))
            {
                throw new KeyNotFoundException("El usuario o la contraseña son incorrectas.");
            }

            string token = CreateToken(user);
            return token;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmach = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmach.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
