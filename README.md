# Sistema CRUD com PostgreSQL e C# WPF

## Resumo

Este repositório contém a implementação prática de um sistema CRUD (Create, Read, Update, Delete) desenvolvido como parte de trabalho de graduação, demonstrando a integração entre um sistema de banco de dados relacional PostgreSQL e uma aplicação desktop em C# utilizando o framework WPF (Windows Presentation Foundation).

O projeto adota uma abordagem de centralização da lógica de negócio por meio de funções armazenadas no banco de dados (PL/pgSQL), reforçando conceitos de segurança, modularidade e desempenho, conforme práticas recomendadas por Silberschatz et al. (2020) e Momjian (2001).

## Objetivos

- Demonstrar a integração prática entre PostgreSQL e aplicações C#
- Implementar arquitetura MVVM com separação clara de responsabilidades
- Centralizar lógica de negócio através de stored procedures e functions
- Aplicar técnicas de validação e integridade de dados no SGBD
- Desenvolver interface gráfica responsiva utilizando WPF e Data Binding

## Arquitetura do Sistema

### Tecnologias Utilizadas

- **Backend**: PostgreSQL 17.2 com PL/pgSQL
- **Frontend**: C# (.NET 8.0) + WPF
- **Padrão Arquitetural**: MVVM (Model-View-ViewModel)
- **Biblioteca de Conexão**: Npgsql
- **Ferramenta de Administração**: pgAdmin 4 v9.0
- **IDE**: Visual Studio 2022
- **Sistema Operacional**: Windows 11

## Modelo de Dados

O sistema utiliza um modelo relacional com três entidades principais:

- **Clientes**: Dados básicos dos clientes (nome, CPF, email, telefone)
- **Endereços**: Endereços associados aos clientes (relacionamento 1:N)
- **Pedidos**: Pedidos realizados pelos clientes (relacionamento 1:N)

### Esquema Conceitual

O modelo segue o padrão relacional proposto por Codd (1970), com definição de chaves primárias, estrangeiras e constraints de integridade.

## Funcionalidades Implementadas

### Operações CRUD

- **Create**: Inserção de novos clientes com validações no banco
- **Read**: Consulta completa de clientes com endereços e pedidos
- **Update**: Atualização de dados existentes
- **Delete**: Exclusão com validação de integridade referencial

### Validações Implementadas

#### No Banco de Dados (PL/pgSQL)
- Validação de campos obrigatórios
- Verificação de formato de CPF (11 dígitos numéricos)
- Prevenção de CPFs duplicados
- Bloqueio de exclusão de clientes com pedidos associados

#### Na Aplicação (C#)
- Tratamento de códigos de retorno das functions
- Manipulação de exceções
- Feedback visual para o usuário

## Segurança

- Uso de comandos parametrizados via Npgsql
- Prevenção contra SQL Injection
- Validações centralizadas no SGBD
- Encapsulamento da lógica de negócio em stored procedures

## Padrões e Boas Práticas

### MVVM (Model-View-ViewModel)
- Separação clara entre apresentação, lógica e dados
- Data Binding para sincronização automática
- Commands para ações da interface
- Dependency Injection para modularização

### Clean Code
- Nomenclatura consistente e descritiva
- Funções com responsabilidade única
- Tratamento adequado de erros e exceções
- Documentação inline do código

## Estrutura das Functions PL/pgSQL

### Function de Inserção
Retorna códigos específicos para cada tipo de validação:
- `0`: Sucesso
- `-100`: Nome inválido
- `-101`: CPF inválido
- `-102`: CPF já existe
- `-999`: Erro genérico

### Function de Seleção
Retorna dados completos através de JOIN entre as tabelas Clientes, Endereços e Pedidos.

### Trigger de Validação
Impede a exclusão de clientes que possuem pedidos associados, mantendo a integridade referencial.

## Contribuições

Este projeto foi desenvolvido como trabalho de graduação em Banco de Dados pela FATEC Bauru. Contribuições são bem-vindas através de:

1. Issues para reportar problemas
2. Pull requests para melhorias
3. Sugestões de otimização

## Metodologia

O desenvolvimento seguiu uma abordagem aplicada e exploratória, dividida em três etapas:

1. **Definição da estrutura de banco de dados** - Modelagem relacional com PKs, FKs e constraints
2. **Implementação das funções em PL/pgSQL** - Centralização da lógica de negócio
3. **Desenvolvimento da interface gráfica** - Integração C# WPF com padrão MVVM

## Autor

Desenvolvido por [João Gabriel](https://github.com/Manhoni) como trabalho de graduação em Banco de Dados.

## Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

---

*Trabalho de Graduação - FATEC | 2025*