# Reactivities

Reactivities é uma aplicação web que permite criar, visualizar, filtrar e comentar atividades em tempo real.  
O projeto combina backend em .NET, frontend em React e comunicação em tempo real com SignalR.  
Este repositório faz parte do meu portfólio e serve como ambiente de estudo de boas práticas de arquitetura, frontend e backend.

---

## 📌 Funcionalidades

- Cadastro e listagem de atividades
- Filtro de atividades (futuras, passadas e as que o usuário logado é o anfitrião)
- Autenticação de usuários
- Comentários em tempo real com SignalR
- Integração frontend + backend
- Deploy automático com GitHub Actions

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

- **API** – ASP.NET Core Web API  
- **Application** – Lógica de aplicação, regras de negócio, DTOs e serviços  
- **Domain** – Entidades 
- **Infrastructure** – Persistência, Entity Framework e integrações  
- **Client** – Frontend em React + TypeScript  

---

## 🛠 Tecnologias Utilizadas

| Camada | Tecnologia |
|--------|----------|
| Backend | ASP.NET Core (.NET 9) |
| ORM | Entity Framework Core |
| Frontend | React + TypeScript |
| UI | Material UI |
| Real-time | SignalR |
| Banco de Dados | SQL Server |
| CI/CD | GitHub Actions |
| Cloud | Microsoft Azure |

---

## 📁 Estrutura do Projeto

- **/API** – Backend em ASP.NET Core  
- **/Application** – Lógica de aplicação, casos de uso e serviços  
- **/Domain** – Entidades e regras de negócio  
- **/Infrastructure** – Persistência, Entity Framework e integrações  
- **/client** – Frontend em React + TypeScript  
- **docker-compose.yml** – Configuração para execução com Docker  

---

## 🚀 Como rodar o projeto localmente

### Pré-requisitos

- .NET 9 SDK  
- Node.js >= 20
- npm ou yarn  

---

### 🔹 Rodando o Backend

1. Acesse a pasta da API:

    ```bash
      cd API
    ```   
2. Restaure os pacotes:

     ```bash
        dotnet restore
      ```
3. Execute as migrations:
      ```bash
        dotnet ef database update
      ```
4. Inicie a API:
      ```bash
        dotnet run
      ```

> A API estará disponível em http://localhost:5001 (ou conforme configurado).
---
### 🔹 Rodando o Frontend

1. Entre na pasta do client:

   ```bash
     cd client
    ```   
2. Instale as dependências:

    ```bash
      npm install
    ```
3. Inicie o React:

   ```bash
      npm run dev
    ```

---
### ⚡ SignalR

O frontend utiliza o pacote @microsoft/signalr para comunicação em tempo real (comentários).
Caso necessário, instale com:
```
  npm install @microsoft/signalr
```
---
### ☁️ Deploy

O projeto está configurado para deploy automático via GitHub Actions para a Microsoft Azure.

O fluxo inclui:

- Build do frontend
- Build do backend
- Publicação no Azure App Service
- Banco de dados no Azure SQL Serverless

> É importante manter os arquivos package.json e package-lock.json versionados para que o build no CI funcione corretamente.

---
👧🏾 **Jenniffer Crystine Souza dos Santos**  
👩🏾‍💻 Backend Developer  
🐙 GitHub: [Jenniffer Souza](https://github.com/JennifferCrystine)  
🔗 Linkedin: [Jenniffer Souza](https://www.linkedin.com/in/jenniffercrystine/)
