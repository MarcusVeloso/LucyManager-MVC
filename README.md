# Lucy Manager

Reservas de salas, laboratórios, auditórios e equipamentos.

A ideia central para esse projeto partiu de um trabalho desenvolvido durante a faculdade, em 2011.
Trata-se de um serviço online para gerenciar reservas de laboratórios de informática.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisities

[Visual Studio 2015 Comunity](https://go.microsoft.com/fwlink/?LinkId=532606)

[ASP.NET 5](https://go.microsoft.com/fwlink/?LinkId=627627)

### Installing

Acesse o Package Manager Console no Visual Studio 2015:
```
Tools > NuGet Package Manager >  Package Manager Console
```
ou use o atalho:
```
ALT + T + N + ENTER 
```
Aguarde ele inicial em na barra na parte inferior do Visual Studio.

Em seguida, insira o seguinte comando para habilitar o Migration

Observação:
Para exibir a operação enquanto ela está sendo executada:
```
-Verbose
```
ou
```
-v
```
Para forçar a operação a ser realizada:
```
-Force
```
ou
```
-f
```

```
Enable-Migragion -v
```

Para gerar o script do banco, utilize o comando abaixo:

```
Add-Migration Initial -v -f
```

Por fim, execute o comando que vai gerar o seu banco:
```
Update-Database -v
```

Feito isso e tudo tendo ocorrido sem problemas, compile a aplicação e execute.

## Built With

* [Bootstrap](getbootstrap.com)

## Author

[* **Marcus Veloso**](https://twitter.com/MarcusvsVeloso)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Cássio Siqueira, por compartilhar dos mesmos ideais tecnológicos e me ajudar a dar vida à primeira versão desse projeto
* [Lucyano Campos](https://github.com/lucyanocm), por ser um excelente profissional, sempre contribuindo para meu crescimento e o da comunidade
