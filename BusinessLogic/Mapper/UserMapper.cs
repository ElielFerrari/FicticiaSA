using BusinessLogic.Dto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public static class UserMapper
    {
        public static User MapToUser(UserDto user, byte[] passwordHash, byte[] passwordSalt )
        {
            return new User
            {
                Username = user.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
        }
        /*
        public static NewClientDto MapToClientDto(this Client client)
        {
            return new NewClientDto
            {
                FullName = client.FullName,
                Age = client.Age,
                Gender = client.Gender,
                Estate = client.Estate,
                Drives = client.Drives,
                HasGlasses = client.HasGlasses,
                HasDiabetes = client.HasDiabetes,
                HasDisease = client.HasDisease,
                DiseaseName = client.DiseaseName
            };
        }*/
    }
}
