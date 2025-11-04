Lista Telefônica API
API desenvolvida em .NET 8 para gerenciar uma lista telefônica.

Tecnologias Utilizadas
.NET 8
ASP.NET Core Web API
MediatR
MongoDB.Driver
Swagger (Swashbuckle)
C# 
Dependency Injection

Estrutura do Projeto
ListaTelefonica.APIAna/
├── Application/
│ ├── Commands/
│ ├── Queries/
│ ├── Handlers/
│ └── DTOs/
├── Controllers/
│ └── ContatosController.cs
├── Infrastructure/
│ ├── Data/
│ ├── Repositories/
│ └── MongoDbContext.cs
├── Models/
│ └── Contato.cs
├── Program.cs
└── appsettings.json

Configuração do Banco de Dados

A API utiliza o MongoDB local na porta padrão 27017.
Certifique-se de que o MongoDB esteja rodando localmente antes de iniciar a aplicação.
ConnectionString padrão:
mongodb://localhost:27017
Banco de dados: ListaTelefonicaDb
Coleção: Contatos

Como Executar o Projeto
Clone o repositório:
git clone https://github.com/anakrauss/ListaTelefonica.APIAna.git

Acesse a pasta do projeto:
cd ListaTelefonica.APIAna

Restaure as dependências:
dotnet restore

Execute o projeto:
dotnet run --environment "Development"

Acesse o Swagger:
http://localhost:5000/swagger

