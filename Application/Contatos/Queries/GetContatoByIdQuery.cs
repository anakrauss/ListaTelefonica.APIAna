using MediatR;
using ListaTelefonica.APIAna.Models;

namespace ListaTelefonica.APIAna.Application.Contatos.Queries
{
    public class GetContatoByIdQuery : IRequest<Contato>
    {
        public string? Id { get; set; }
    }
}
