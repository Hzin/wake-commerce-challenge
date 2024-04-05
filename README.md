# wake-challenge

A API consiste em um CRUD de produtos, no qual a entidade produto é formada por id, nome, estoque e valor.

API .NET 8 utilizando PostgreSQL como banco de dados com ORM Entity Framework Code-First e como regra para as mensagens de commits seguindo https://www.conventionalcommits.org/en/v1.0.0/. Os testes unitários são feitos automaticamente ao realizar um PR para a branch main ou um push atráves do workflow criado.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

Consulte **[Implantação](#-implanta%C3%A7%C3%A3o)** para saber como implantar o projeto.

### 📋 Pré-requisitos

De que coisas você precisa para instalar o software e como instalá-lo?

```
PostgreSQL 14 ou superior
```
```
Visual Studio 2022
```
```
Sistema operacional Windows, Linux ou Mac
```

### 🔧 Instalação

Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de desenvolvimento em execução.

Diga como essa etapa será:

```
Clone esse repositório
```
```
Abra a solução no Visual Studio
```
```
Compile o projeto
```
```
Abra o console do gerenciador de pacotes ( Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes )
```
```
**OBS: As informações de conexão do banco de dados se encontram no arquivo Program.cs dentro do projeto WakeChallenge.API caso a sua senha e/ou login seja diferente altere antes de executar o comando**
Execute o comando para criar a base de dados "update-database"
```

## ⚙️ Executando os testes

Para executar os testes unitários manualmente vá na aba Teste > Executar Todos os Testes ou com as teclas de atalho (Ctrl+R, A).
Lembrando que os testes são executados automaticamente ao abrir um PR para a branch main ou realizar um push, é possível visualizar os testes na aba Actions no repositório do GitHub.

# Status dos testes unitários
[![build and test](https://github.com/Hzin/wake-commerce-challenge/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/Hzin/wake-commerce-challenge/actions/workflows/build-and-test.yml)

## 🛠️ Construído com

* [PostgreSQL](https://www.postgresql.org/) - Banco de dados
* [.NET 8.0](https://learn.microsoft.com/en-us/dotnet/framework/) - Framework

---
⌨️ com ❤️ por [Hugo Falcão](https://github.com/Hzin) 😊
