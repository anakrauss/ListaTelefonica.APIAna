using MediatR;

namespace ListaTelefonica.APIAna.Application.Contatos.Commands
{
    public class DeleteContatoCommand : IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
