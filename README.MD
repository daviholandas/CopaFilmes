
# Campeonato de Filmes

Esta é uma aplicação onde podemos disputar uma competição entre filmes. Você escolhe 8 filmes aleatorios e no final será mostrado o campẽao e o vice.

## Como utilizar

Para criar rapidamente o ambiente está disponibilizado as imagens Docker dos 2 recursos da aplicação:

- [WebApp SPA Copa Filmes](https://hub.docker.com/repository/docker/daviholandas/copafilmeswepapp)
- [Web API ASP.NET Core](https://hub.docker.com/repository/docker/daviholandas/copafilmeswebapi)

> **Requisito:** É necessário ter o docker instalado em seu sistema operacional (Linux, Windows ou Mac)

#### Caso não queria usar o docker
- `As duas aplicações estão em pastas separadas, clone o respositorio para um local de sua preferencia, navegue até o projeto desejado e execute os comandos:
`- dotnet run (para WebAPi);`
`- ng s ou npm y server (para a WebApp);`

## Sobre a Api
- `Ela está versionada e documentada. Para acessar a documentação basta ir em http://localhost:5001/swagger `

### Para rodar a aplicação
Rode o comando (apontando a pasta local do arquivo):  
- ` docker-compose -f docker-compose.copafilmes up` 

#### É possível renomear um dos arquivos para 'docker-compose.yml' e rodar o comando mais simplificado:  
- ` docker-compose up` 

#### Para parar a execução no console (executando no modo 'detached'):  
- ` docker-compose down` 

#### Para parar a execução no console (executando no modo 'attached'):  
- <kbd>Crtl</kbd> + <kbd>C</kbd>

## Sobre os testes
- `A aplicacão foi construida usando o TDD então existem testes unitário. Alguns métodos privados foram escritos usando TDD e depois o teste foi apagado para não causar problemas quando fosse rodar a bateria de testes.`

## Suporte

Se tiver alguma duvida é só me mandar um e-mail [daviholandas@gmail.com](mailto:daviholandas@gmail.com)
