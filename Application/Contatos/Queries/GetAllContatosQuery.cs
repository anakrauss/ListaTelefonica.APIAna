using System.Collections.Generic;
using MediatR;
using ListaTelefonica.APIAna.Models;

namespace ListaTelefonica.APIAna.Application.Contatos.Queries
{
    public class GetAllContatosQuery : IRequest<IEnumerable<Contato>> { }
}
