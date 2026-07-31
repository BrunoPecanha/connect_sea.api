# Connect Sea Challenge - API

API desenvolvida como parte do desafio técnico da Connect Sea.

O projeto consiste em uma API REST desenvolvida em .NET, com foco em organização, boas práticas de desenvolvimento e separação de responsabilidades.

---

## 🚀 Tecnologias utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI
- Docker

---

## 📁 Estrutura do projeto

```
src/
├── API              # Controllers e configurações da aplicação
├── Application      # Serviços, DTOs e regras de aplicação
├── Domain           # Entidades e regras de negócio
└── Infrastructure   # Persistência e acesso a dados
```

---

## ⚙️ Pré-requisitos

Antes de executar o projeto, é necessário possuir instalado:

- .NET SDK 8
- PostgreSQL ou Docker
- Git

---

## 📥 Clonando o projeto

```bash
git clone <repository-url>
```

Acesse a pasta:

```bash
cd <project-folder>
```

---

## 🔧 Configuração

Configure a conexão com o banco de dados no arquivo:

```
appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=connectsea;Username=postgres;Password=postgres"
  }
}
```

---

## 🗄️ Banco de dados

O projeto utiliza Entity Framework Core com migrations.

Para criar/atualizar a estrutura do banco:

```bash
dotnet ef database update
```

Caso necessário, instale a ferramenta:

```bash
dotnet tool install --global dotnet-ef
```

---

## ▶️ Executando a aplicação

Restaurar dependências:

```bash
dotnet restore
```

Compilar:

```bash
dotnet build
```

Executar:

```bash
dotnet run
```

A API estará disponível em:

```
https://localhost:{porta}
```

---

## 📚 Documentação da API

A documentação dos endpoints está disponível através do Swagger:

```
/swagger
```

Exemplo:

```
https://localhost:{porta}/swagger
```

---

## 🐳 Executando com Docker

Criar a imagem:

```bash
docker build -t connectsea-api .
```

Executar o container:

```bash
docker run -p 8080:8080 connectsea-api
```

---

## 🧪 Testes

Para executar os testes automatizados:

```bash
dotnet test
```

---

## 📝 Decisões técnicas

- Arquitetura organizada em camadas para separação de responsabilidades.
- Uso de DTOs para controlar os dados expostos pela API.
- Entity Framework Core para gerenciamento da persistência.
- Migrations para versionamento do banco de dados.
- Swagger/OpenAPI para documentação e testes dos endpoints.
- Aplicação seguindo princípios de código limpo e boas práticas do ecossistema .NET.

---

## 👨‍💻 Autor

Bruno Martins Peçanha
