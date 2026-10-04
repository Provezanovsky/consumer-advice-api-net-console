# Consumer Advice API

Aplicação console em C#/.NET desenvolvida para a disciplina de Desenvolvimento Web.

## Objetivo

Consumir a API de conselhos aleatórios disponível no endpoint:

`https://api.adviceslip.com/advice`

A aplicação faz uma requisição HTTP, interpreta o JSON retornado e exibe no console o valor do campo `advice`.

## Exemplo de execução

```text
Iniciando requisição para obter dados de um conselho:

https://api.adviceslip.com/advice

Conselho de Hoje:
Things are just things. Don't get too attached to them.
```

Como o conselho é aleatório, o texto retornado pode ser diferente a cada execução.

## Tecnologias utilizadas

- C#
- .NET 8
- HttpClient
- System.Text.Json

## Como executar

Com o SDK do .NET instalado, execute no terminal:

```bash
dotnet run
```
