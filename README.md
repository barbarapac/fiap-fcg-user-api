# fiap-fcg-user-api

**Microsserviço de Usuários** do ecossistema FIAP Cloud Games. Responsável por autenticação, registro e administração de perfis, esse serviço opera de forma isolada e integrada aos demais serviços via APIs REST, seguindo princípios de microsserviços e implantação em nuvem (Azure).

## TechChallenge CloudGames

API REST independente e escalável, desenvolvida como parte do Tech Challenge da FIAP. Essa aplicação foi extraída de um monolito e redesenhada como **microsserviço**, com base em Clean Architecture, uso de Entity Framework Core com PostgreSQL e autenticação JWT.

## Sobre o Projeto

O objetivo é fornecer um microsserviço resiliente e coeso para o gerenciamento de usuários da plataforma de jogos FIAP Cloud Games. Ele pode ser implantado e escalado de forma autônoma, cumprindo um papel específico dentro da arquitetura distribuída da aplicação.

### Arquitetura

O microsserviço segue os princípios da **Clean Architecture**, promovendo separação de responsabilidades, testabilidade e independência entre camadas:

- `WebApi`: camada HTTP com controle de rotas, autenticação e Swagger.
- `Application`: coordena casos de uso e regras de negócio.
- `Domain`: regras de domínio, entidades e validações.
- `Infrastructure`: implementações de repositórios com EF Core e integrações (ex: JWT).

### Pré-requisitos

| Requisito        | Link para Download   |
| ---------------- |----------------------|
| `.NET SDK 8.0`   | [Baixar aqui](https://dotnet.microsoft.com/en-us/download)   |
| `PostgreSQL 14+` | [Baixar aqui](https://www.postgresql.org/download/)   |
| `Docker`         | [Baixar aqui](https://www.docker.com/products/docker-desktop/)   |
| `Docker Compose` | [Baixar aqui](https://docs.docker.com/compose/install/)   |

## Execute localmente

<details><summary>1. Clone o repositório</summary>
  
```bash
git clone https://github.com/seu-usuario/fiap-fcg-user-api.git
cd fiap-fcg-user-api
```

</details> 

<details><summary>2. Suba o banco de dados com Docker Compose</summary>
  
```bash
docker-compose up -d
```
Certifique-se de usar a porta certa, por exemplo: 5433.

</details> 

<details><summary>3. Configure a string de conexão</summary>
  
```json
"USER_CONNECTION_STRING": "Host=localhost;Port=5433;Database=fcg_users_db;Username=postgres;Password=postgres",
```

</details> 

<details><summary>4. Aplique as migrations</summary>
  
```bash
dotnet ef database update \
  --project src/Fiap.FCG.User.Infrastructure \
  --startup-project src/Fiap.FCG.User.WebApi
```

</details> 

<details><summary>5. Execute a aplicação</summary>
  
```bash
dotnet run --project src/Fiap.FCG.User.WebApi
```

Acesse: [https://localhost:8181/swagger](https://localhost:8181/swagger)
</details>

## Tecnologias Utilizadas
| Tecnologia            | Link                                                                                                                                                   |
| --------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| .NET 8                | [https://learn.microsoft.com/en-us/dotnet/](https://learn.microsoft.com/en-us/dotnet/)                                                                 |
| Entity Framework Core | [https://learn.microsoft.com/en-us/ef/core/](https://learn.microsoft.com/en-us/ef/core/)                                                               |
| PostgreSQL            | [https://www.postgresql.org/docs/](https://www.postgresql.org/docs/)                                                                                   |
| Swashbuckle (Swagger) | [https://github.com/domaindrivendev/Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)                                 |
| MediatR               | [https://github.com/jbogard/MediatR](https://github.com/jbogard/MediatR)                                                                               |
| JWT Authentication    | [https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt) |

### Variáveis de Ambiente

| Variável       | Descrição                              | Obrigatório | Exemplo                       |
| -------------- | -------------------------------------- | ----------- | ----------------------------- |
| `JWT_KEY`      | Chave secreta para assinar o token JWT | Sim         | `"minha-chave-super-secreta"` |
| `JWT_ISSUER`   | Emissor do token JWT                   | Sim         | `"Fiap.FCG"`                  |
| `JWT_AUDIENCE` | Público-alvo do token JWT              | Sim         | `"Fiap.FCG"`                  |
