# opentracing-examples

## Como rodar

[KISS](https://pt.wikipedia.org/wiki/Princ%C3%ADpio_KISS)

`docker-compose up --build`

## Aplicações de exemplo

- `app1-without-trace`, rodando em http://localhost:8081
- `app1-with-trace`, rodando em http://localhost:8082
- `app2`, rodando em http://localhost:8083
- `jaeger-ui`, rodando em http://localhost:16686

### app-1

Uma aplicação que executa 3 regras, a primeira faz uma chamada `http` para o serivço `app-2` e as outras duas tem 50% de chance de falhar.

Teremos uma instância que os traces estão desabilitados para simular o caso de pior exemplo.

## Referências

* https://github.com/opentracing-contrib/csharp-netcore
* https://github.com/plusultraland/PlusUltra.OpenTracing.HttpPropagation
* https://opentracing.io/
* https://opentelemetry.io/
* https://www.jaegertracing.io/
* https://opentracing.io/docs/overview/
* https://opentracing.io/specification/