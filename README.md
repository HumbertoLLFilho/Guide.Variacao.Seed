# Guide.Variacao.Seed

## Funcionamento

:bangbang:**Importante**:bangbang:

O banco de dados escolhido para a poc foi o [PostgreSQL](https://www.postgresql.org/download/windows/),
quaisquer dúvidas para instalar e configurar, consultar o site.

### Configurando o appSettings
Foi inserido um appsettings padrão no aplicativo. É preciso fazer a devida configuração utilizando as credenciais de seu banco local para que todo o código seja executado.

Seguindo o exemplo:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localHost;Database=GuideVariacao;User Id=MeuUsuarioPadrao;Password=123"
},
```

Devemos trocar o `Id=MeuUsuarioPadrao` pelo usuário admin do local e `Password=123` pela sua senha,
o banco e estrutura são criados pelo próprio *EF Core* :tada:

### Execução
Para facilitar a criação e inserção dos dados e garantir um banco limpo toda vez que quisermos, criei esse projeto com o intuito de fazer o "seed" e alimentar todo o banco de dados.

Por padrão a API do Yahoo Finance é consultada de forma que todos os dados de 10 ativos diferentes são armazenados no nosso banco, estão todos presentes no namespace:

`Guide.Variacao.Seed.Core.Models`

Para o correto funcionamento precisamos apenas executar o projeto de *Console App*, assim todo o banco é gerado na sua máquina


### Finalizando
Esse projeto foi feito para termos uma fácil configuração do nosso *Backend* sendo assim muito mais tranquilo utilizar de nossa API!
