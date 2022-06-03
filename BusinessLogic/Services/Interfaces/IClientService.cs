using BusinessLogic.Dto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IClientService
    {
        Task AddClient(NewClientDto clientDto);
        Task <List<NewClientDto>> GetAll();
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
