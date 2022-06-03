using BusinessLogic.Dto;
using BusinessLogic.Mapper;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;

        public ClientService(DataContext context)
        {
            _context = context;
        }

        public async Task AddClient(NewClientDto clientDto)
        {
            var client = ClientMapper.MapToClient(clientDto);

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }


        public async Task<List<NewClientDto>> GetAll()
        {
            var clientList = await _context.Clients.ToListAsync();

            return clientList.Select(x => ClientMapper.MapToClientDto(x)).ToList();
        }

        public async Task UpdateClient(Client client)
        {
            var clientExits = await _context.Clients.AnyAsync(x => x.Id == client.Id);

            if (clientExits)
            {
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El cliente con el id ingresado no existe.");
            }
        }
        public async Task DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("El cliente con el id ingresado no existe.");
            }
        }
    }
}
