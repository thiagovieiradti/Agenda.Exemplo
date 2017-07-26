# Agenda.Exemplo
Aplicação de Agenda exemplo para utilização de tecnologias nos projetos dti/supermix.


## Banco de dados
O script para criação do banco de dados está na pasta \Banco.

![MER](/Diagramas/mer.png)

## Aplicação

A aplicação é composta por um servidor RestAPI e um Site Web.

Algumas tecnologias utilizadas:

* RestAPI
	* WebAPI2 + Swagger
	* SimpleInjector
	* Dapper
	* Visual Studio Test Framework

* Site Web
	* Knockout.js
	* Bootstrap

## Arquitetura Backend
![Backend](/Diagramas/backend.jpg)

## Arquitetura JS
![Frontend](/Diagramas/frontend.jpg)

## Para executar

* RestAPI: http://localhost:53546/swagger
* Site: http://localhost:56321/

## to-do list
@matheusaraujo
1. refatoração do injetor de dependências
1. finalizar crud de cliente
1. criar operação de registrar chamadas
1. criar lista de chamadas
1. redesenhar diagramas