using System;
using System.Collections.Generic;
using MediatR;
using ListaTelefonica.APIAna.Models;

namespace ListaTelefonica.APIAna.Application.Contatos.Commands
{
    public class UpdateContatoCommand : IRequest<Contato>
    {
        public string? Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? DataNascimento { get; set; }
        public List<Endereco>? Enderecos { get; set; }
    }
}
