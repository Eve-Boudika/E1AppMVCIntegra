using E1WebMVC.Repository.Models;
using E1WebMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E1WebMVC.Service.Dtos;

namespace E1WebMVC.Service
{
    public class ClientService
    {
        private readonly ClientRepository clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> Get()
        {
            var clientsDtoList = await clientRepository.Get();

            #region Mapper
            var clientDtoList = new List<ClientDto>();
            foreach (var client in clientsDtoList)
            {
                var clientDto = new ClientDto();
                clientDto.Cuit = client.Cuit;
                clientDto.Activo = client.Activo;
                clientDto.RazonSocial = client.RazonSocial;
                clientDto.Direccion = client.Direccion;
                clientDto.Id = client.Id;
                clientDto.Telefono = client.Telefono;

                clientDtoList.Add(clientDto);
            }
            #endregion


            return clientDtoList;
        }
    }
}
