# Em desenvolvimento com C# e Angular.

Estrutura da API.

```
MinhaApi/
│
├── MinhaApi.sln
│
├── src/
│   ├── MinhaApi.Api/
│   ├── MinhaApi.Application/
│   │   ├── Interfaces/
│   │   │   └── IUserRepository.cs
│   │   ├── Services/
│   │   │   └── UserService.cs
│   │
│   ├── MinhaApi.Domain/
│   │   ├── Entities/
│   │   │   └── User.cs
│   │
│   ├── MinhaApi.Infrastructure/
│   │   ├── Repositories/
│   │   │   └── UserRepository.cs
│   │   ├── Data/
│   │   │   ├── Configurations/
│   │   │   └── AppDbContext.cs
│
├── tests/
│   ├── MinhaApi.UnitTests/
│   ├── MinhaApi.IntegrationTests/
```
