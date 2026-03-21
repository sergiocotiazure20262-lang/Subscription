using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Repositories;
using Subscription.Domain.Interfaces.Services;
using Subscription.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio de cliente.
    /// </summary>
    public class ClienteService (IUnitOfWork unitOfWork) : IClienteService
    {
        public async Task<ClienteResponse> CriarAsync(ClienteRequest request)
        {
            //Verificar o nome do cliente
            if (string.IsNullOrEmpty(request.nome) || request.nome.Trim().Length < 6)
                throw new ArgumentException("Nome do cliente é obrigatório e deve ter pelo menos 6 caracteres.");

            //Capturar o email do cliente (ValueObject já executa a validação)
            var email = new Email(request.email);

            //Regra: Email único no banco de dados
            var existente = await unitOfWork.ClienteRepository.CountAsync(c => c.Email.Endereco.Equals(email.Endereco));
            if (existente > 0)
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");

            //Criando o cliente
            var cliente = new Cliente
            {
                Nome = request.nome,
                Email = email
            };

            //Salvando no banco de dados
            await unitOfWork.ClienteRepository.AddAsync(cliente);
            await unitOfWork.SaveChangesAsync();

            //retornar os dados
            return ToResponse(cliente);
        }

        public async Task<ClienteResponse> ObterAsync(string email)
        {
            //Buscar os dados do cliente baseado no email
            var cliente = await unitOfWork.ClienteRepository.FirstOrDefaultAsync(c => c.Email.Endereco.Equals(email));

            //Cliente não encontrado
            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado. Verifique o email informado.");

            //Retornar os dados do cliente
            return ToResponse(cliente);
        }

        private ClienteResponse ToResponse(Cliente cliente)
        {
            return new ClienteResponse(
                    cliente.Id,
                    cliente.Nome,
                    cliente.Email.Endereco,
                    cliente.DataCadastro,
                    cliente.Status.ToString()
                );
        }
    }
}
