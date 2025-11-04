using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using ListaTelefonica.APIAna.Models;
using ListaTelefonica.APIAna.Application.Contatos.Commands;
using ListaTelefonica.APIAna.Application.Contatos.Queries;
using System;

namespace ListaTelefonica.APIAna.Application.Contatos.Handlers
{
    public class GetAllContatosHandler : IRequestHandler<GetAllContatosQuery, IEnumerable<Contato>>
    {
        private readonly IMongoCollection<Contato> _collection;
        public GetAllContatosHandler(IMongoCollection<Contato> collection) => _collection = collection;

        public async Task<IEnumerable<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
        {
            return await _collection.Find(_ => true).ToListAsync(cancellationToken);
        }
    }

    public class GetContatoByIdHandler : IRequestHandler<GetContatoByIdQuery, Contato>
    {
        private readonly IMongoCollection<Contato> _collection;
        public GetContatoByIdHandler(IMongoCollection<Contato> collection) => _collection = collection;

        public async Task<Contato> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _collection.Find(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        }
    }

    public class CreateContatoHandler : IRequestHandler<CreateContatoCommand, Contato>
    {
        private readonly IMongoCollection<Contato> _collection;
        public CreateContatoHandler(IMongoCollection<Contato> collection) => _collection = collection;

        public async Task<Contato> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contato
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Enderecos = request.Enderecos ?? new List<Endereco>()
            };

            await _collection.InsertOneAsync(contato, null, cancellationToken);
            return contato;
        }
    }

    public class UpdateContatoHandler : IRequestHandler<UpdateContatoCommand, Contato>
    {
        private readonly IMongoCollection<Contato> _collection;
        public UpdateContatoHandler(IMongoCollection<Contato> collection) => _collection = collection;

        public async Task<Contato> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null) return null!;
            var filter = Builders<Contato>.Filter.Eq(c => c.Id, request.Id);
            var update = Builders<Contato>.Update
                .Set(c => c.Nome, request.Nome)
                .Set(c => c.Telefone, request.Telefone)
                .Set(c => c.Email, request.Email)
                .Set(c => c.DataNascimento, request.DataNascimento)
                .Set(c => c.Enderecos, request.Enderecos ?? new List<Endereco>());

            var options = new FindOneAndUpdateOptions<Contato> { ReturnDocument = ReturnDocument.After };
            var updated = await _collection.FindOneAndUpdateAsync(filter, update, options, cancellationToken);
            return updated;
        }
    }

    public class DeleteContatoHandler : IRequestHandler<DeleteContatoCommand, bool>
    {
        private readonly IMongoCollection<Contato> _collection;
        public DeleteContatoHandler(IMongoCollection<Contato> collection) => _collection = collection;

        public async Task<bool> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null) return false;
            var res = await _collection.DeleteOneAsync(c => c.Id == request.Id, cancellationToken);
            return res.DeletedCount > 0;
        }
    }
}
