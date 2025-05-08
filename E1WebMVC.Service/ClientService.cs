using E1WebMVC.Repository.Models;
using E1WebMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E1WebMVC.Service.Dtos;
using Microsoft.EntityFrameworkCore;

namespace E1WebMVC.Service
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> Get()
        {
            var clientsDtoList = await _clientRepository.Get();

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

        public async Task<ClientDto> GetById(int id)
        {

            var client = await _clientRepository.GetById(id);
            var clientDto = new ClientDto();

            if (client is null)
            {
                return null;
            }
            else
            {
                clientDto.Cuit = client.Cuit;
                clientDto.Activo = client.Activo;
                clientDto.RazonSocial = client.RazonSocial;
                clientDto.Direccion = client.Direccion;
                clientDto.Id = client.Id;
                clientDto.Telefono = client.Telefono;
            }
            return clientDto;
        }

        public async Task<ClientDto> Update(Clientes client)
        {
            var response = await _clientRepository.Update(client);
            if (response is 0)
            {
                return null;
            }
            var clientDto = new ClientDto();

            clientDto.Cuit = client.Cuit;
            clientDto.Activo = client.Activo;
            clientDto.RazonSocial = client.RazonSocial;
            clientDto.Direccion = client.Direccion;
            clientDto.Id = client.Id;
            clientDto.Telefono = client.Telefono;
            return clientDto;
        }

        public async Task<int> Delete(int id)
        {
            return await _clientRepository.Delete(id);
        }
        public async Task<int> Create(Clientes client)
        {
            return await _clientRepository.Create(client);
        }
    }
}
