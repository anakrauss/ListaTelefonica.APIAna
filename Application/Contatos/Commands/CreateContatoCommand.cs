using System;
using System.Collections.Generic;
using MediatR;
using ListaTelefonica.APIAna.Models;

namespace ListaTelefonica.APIAna.Application.Contatos.Commands
{
    public class CreateContatoCommand : IRequest<Contato>
    {
        public string Nome { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        public List<Endereco>? Enderecos { get; set; }
    }
}
