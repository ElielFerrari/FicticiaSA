using BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
    }
}
