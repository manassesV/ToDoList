# 📋 ToDoList API

[![.NET](https://img.shields.io/badge/.NET-7.0-blue)](https://dotnet.microsoft.com/)  
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-7.0-green)](https://docs.microsoft.com/ef/)  
[![Swagger](https://img.shields.io/badge/Swagger-Enabled-yellow)](https://swagger.io/)  
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://opensource.org/licenses/MIT)

API REST para gerenciamento de tarefas (ToDo), implementando boas práticas como CQRS, MediatR, versionamento de API, validações e documentação via Swagger.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 7
- MediatR
- Entity Framework Core 7
- API Versioning
- Swagger / Swashbuckle
- FluentValidation

---

## 📁 Estrutura do Projeto

```
ToDoList/
├── ToDoList.API/
│   ├── Controllers/
│   │   └── TodoTaskController.cs
│   ├── Commands/
│   │   ├── CreateTodoTaskCommand.cs
│   │   └── UpdateTodoTaskCommand.cs
│   ├── Services/
│   │   └── TodoTaskServices.cs
│   └── Program.cs
│
├── ToDoList.Infrastructure/
│   ├── Data/
│   │   └── AppDbContext.cs
│   └── Migrations/
```

![Arquitetura do projeto](https://github.com/user-attachments/assets/04fdc5d6-dd74-4d5d-9f02-85c22bee988f)

---

## 📦 Como Executar

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/todolist.git
cd todolist
```

### 2. Restaurar pacotes e compilar

```bash
dotnet restore
dotnet build
```

### 3. Configure a string de conexão

Altere a string de conexão no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "todolistdb": "Server=(LocalDb)\MSSQLLocalDB;Database=todolistdb;Trusted_Connection=True;"
}
```

### 4. Aplicar as migrations

```bash
dotnet ef migrations add NomeDaMigration --project ./ToDoList.Infrastructure --startup-project ./ToDoList.API
dotnet ef database update --project ./ToDoList.Infrastructure --startup-project ./ToDoList.API
```

### 5. Executar a aplicação

```bash
dotnet run --project ./ToDoList.API
```

### 6. Acessar a documentação Swagger

Abra no navegador:

```
https://localhost:{porta}/swagger
```

---

## 📘 Endpoints da API (v1)

| Método | Rota                   | Descrição                     |
|--------|------------------------|-------------------------------|
| POST   | /api/v1/TodoTask       | Cria uma nova tarefa          |
| GET    | /api/v1/TodoTask       | Lista todas as tarefas        |
| GET    | /api/v1/TodoTask/{id}  | Busca uma tarefa pelo ID      |
| PUT    | /api/v1/TodoTask/{id}  | Atualiza uma tarefa existente |

---

## 🧪 Exemplo de Payload

### Criar / Atualizar Tarefa

```json
{
  "name": "Revisar PR",
  "description": "Analisar Pull Request do time",
  "dueDate": "2025-05-20T18:00:00",
  "status": 0
}
```

---

## 🛠️ Comandos Úteis

### Criar uma nova migration

```bash
dotnet ef migrations add NomeDaMigration --project ./ToDoList.Infrastructure --startup-project ./ToDoList.API
```

### Atualizar o banco de dados

```bash
dotnet ef database update --project ./ToDoList.Infrastructure --startup-project ./ToDoList.API
```

---

## 📄 Licença

Distribuído sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Abra uma issue ou envie um pull request com melhorias, correções ou sugestões.
