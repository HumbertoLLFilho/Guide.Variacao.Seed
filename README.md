# Guide.Variacao.Core

## Funcionamento

:bangbang:**Importante**:bangbang:

O banco de dados escolhido para a poc foi o [PostgreSQL](https://www.postgresql.org/download/windows/),
quaisquer duvidas para instalar e configurar, consultar o site.

### Configurando o appSettings
Foi inserido um appsettings padrão no app, é preciso configurar para as credenciais de seu banco local para que todo o código seja executado.

Seguindo o exemplo:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localHost;Database=GuideVariacao;User Id=MeuUsuarioPadrao;Password=123"
},
```

Devemos trocar o `Id=MeuUsuarioPadrao` pelo usuario admin do local e `Password=123` pela sua senha,
o banco e estrutura são criados pelo próprio *EF Core* :tada:

### Execução
Para facilitar a criação e inserção dos dados e garantir um banco limpo toda vez que quisermos, criei esse projeto com o intuito de fazer o "seed" e alimentar todo o banco de dados.

por padrão a API do Yahoo Finance é consultada de forma que todos os dados de 10 ativos diferentes são armazenados no nosso banco, estão todos presentes no namespace:

`Guide.Variacao.Seed.Core.Models`

Para o correto funcionamento precisamos apenas executar o projeto de *Console App*, assim todo o banco é gerado na sua maquina


### Finalizando
Esse projeto foi feito para termos uma facil configuração do nosso *Backend* sendo assim muito mais tranquilo utilizar de nossa API!
