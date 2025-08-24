# Board Processing com RabbitMQ & Redis

[![](https://img.shields.io/badge/-RabbitMQ-333333?style=flat&logo=visual-studio-code&logoColor=007ACC)](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet)
[![](https://img.shields.io/badge/-Redis-333333?style=flat&logo=visual-studio-code&logoColor=007ACC)](https://redis.io/docs/latest/develop/clients/dotnet/)

Uma simulação avançada de orquestração no consumo de componentes de Boards, utilizando RabbitMQ como serviço de mensageria para comunicação assíncrona e Redis como camada de cache em memória, garantindo alta performance e baixa latência no processamento.

## Cenário: 
O projeto simula um pipeline de `mensageria` voltado ao consumo de componentes de *Boards*. O cenário considerado envolve equipes externas à TI que necessitam consultar esses dados para reports de consumos e inventário, porém sem acesso direto ao banco de dados - produção ou réplica. A empresa possui um banco de dados robusto e consolidado. Diante disso, a solução proposta foi o desenvolvimento de uma aplicação Console, utilizando `Dapper` para executar *stored procedures* responsáveis por retornar, em tempo real, os componentes consumidos. A arquitetura proposta resolve essa limitação publicando os dados em um `message broker`, que atua como camada intermediária de distribuição. Dessa forma, os consumidores podem acessar as informações de forma segura, desacoplada e com controle de permissões, garantindo isolamento do ambiente e integridade dos dados.

## Tecnologias:
- .NET
- RabbitMQ
- Redis
- Docker & Docker compose
- SQL Server

## Como executar:
- Clone o repositorio:
```bash
https://github.com/brunopsouz/board-process-rabbitmq-redis.git
```
- Up the Docker containers:
```bash
docker-compose up -d
```
