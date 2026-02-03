# Gerenciador de Tarefas Fullstack

Este projeto é um **Gerenciador de Tarefas Fullstack** desenvolvido com uma API RESTful em **.NET 8.0** e um frontend reativo em **React**. Ele foi arquitetado com foco em **Clean Architecture**, utilizando **Entity Framework Core** para persistência de dados em **SQL Server**, e seguindo **padrões RESTful** para a comunicação entre as camadas. O objetivo principal é demonstrar boas práticas de engenharia de software, desacoplamento e manutenibilidade.

<img width="1702" height="911" alt="image" src="https://github.com/user-attachments/assets/0092dd91-f260-40c5-805d-b3071f5639f8" />


## Tecnologias Utilizadas

### Backend (API .NET)

*   **Linguagem/Framework:** C# / .NET 8.0
*   **Banco de Dados:** SQL Server
*   **ORM:** Entity Framework Core
*   **Padrões de API:** RESTful
*   **Documentação da API:** Swashbuckle (Swagger/OpenAPI)
*   **Arquitetura:** Clean Architecture

### Frontend (React)

*   **Framework:** React (^19.2.0)
*   **Build Tool:** Vite (^5.2.4)
*   **Linguagem:** JavaScript/TypeScript
*   **Linting:** ESLint

## Arquitetura do Projeto

O projeto segue os princípios da **Clean Architecture**, promovendo o desacoplamento e a separação de responsabilidades. As principais camadas são:

*   **ToDoList.Api:** Camada de apresentação, responsável por expor os endpoints RESTful e orquestrar as requisições.
*   **ToDoList.Application:** Contém a lógica de negócio da aplicação, incluindo casos de uso e interfaces para serviços externos.
*   **ToDoList.Communication:** Define os contratos de comunicação (DTOs, comandos, queries) entre as camadas.
*   **ToDoList.Domain:** O coração da aplicação, contendo as entidades de negócio, regras e validações.
*   **ToDoList.Infrastructure:** Implementa as interfaces definidas na camada de domínio, lidando com detalhes de infraestrutura como acesso a dados (Entity Framework Core) e serviços externos.

## Funcionalidades

Como um gerenciador de tarefas, o projeto oferece as seguintes funcionalidades:

*   Criação de novas tarefas.
*   Visualização de todas as tarefas existentes.
*   Marcação de tarefas como concluídas.
*   Edição de tarefas.
*   Exclusão de tarefas.

## Como Rodar o Projeto

Para configurar e executar este projeto em sua máquina local, siga os passos abaixo:

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

*   [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
*   [Node.js](https://nodejs.org/en/download/) (versão LTS recomendada)
*   [npm](https://www.npmjs.com/get-npm) ou [Yarn](https://yarnpkg.com/)
*   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (ou uma instância acessível)

### Configuração do Backend

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/leomarqueti/todo-list-fullstack.git
    cd todo-list-fullstack
    ```
2.  **Configure o Banco de Dados:**
    *   Abra o arquivo `ToDoList.Api/appsettings.json`.
    *   Atualize a string de conexão `ConnectionStrings:Connection` para apontar para sua instância do SQL Server.
    *   Exemplo:
        ```json
        "ConnectionStrings": {
            "Connection": "Server=localhost;Database=ToDoListDB;User Id=sua_conta;Password=sua_senha;TrustServerCertificate=True;"
        }
        ```
    *   Execute as migrações do Entity Framework Core para criar o banco de dados e as tabelas:
        ```bash
        cd ToDoList.Api
        dotnet ef database update
        cd ..
        ```
3.  **Execute a API:**
    ```bash
    cd ToDoList.Api
    dotnet run
    ```
    A API estará disponível em `https://localhost:7001` (ou outra porta configurada).
    A documentação Swagger estará acessível em `https://localhost:7001/swagger`.

### Configuração do Frontend

1.  **Navegue até a pasta do frontend:**
    ```bash
    cd frontend/meu-app
    ```
2.  **Instale as dependências:**
    ```bash
    npm install
    # ou yarn install
    ```
3.  **Execute a aplicação React:**
    ```bash
    npm run dev
    # ou yarn dev
    ```
    O aplicativo frontend estará disponível em `http://localhost:5173` (ou outra porta configurada).

## Estrutura de Pastas

```
todo-list-fullstack/
├── ToDoList.Api/             # Camada de apresentação (API RESTful)
├── ToDoList.Application/     # Lógica de negócio e casos de uso
├── ToDoList.Communication/   # Contratos de comunicação (DTOs)
├── ToDoList.Domain/          # Entidades de domínio e regras de negócio
├── ToDoList.Infrastructure/  # Implementação de persistência e serviços externos
├── frontend/                 # Aplicação frontend (React)
│   └── meu-app/              # Projeto React com Vite
└── ToDoList.sln              # Solução Visual Studio
```

## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE.txt](LICENSE.txt) para mais detalhes.

## Autor

[Leonardo Marqueti](https://github.com/leomarqueti)

