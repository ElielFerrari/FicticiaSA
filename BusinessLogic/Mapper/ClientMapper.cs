using BusinessLogic.Dto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public static class ClientMapper
    {
        public static Client MapToClient(NewClientDto client)
        {
            return new Client
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
        }

        public static NewClientDto MapToClientDto(Client client)
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
        }
    }
}
