![This is an image](https://endeavor.org.br/wp-content/uploads/2020/04/neon-360x81.png)

Teste técnico para Desenvolvedor Back-End Pleno para a Neon Pagamentos.

## Objetivo

Construir um worker que recebe uma lista de depósitos a serem efetuados dentro do Banco Novidade, creditando na
conta corrente do cliente - Agencia: 0001 - Banco Novidade

* Receber a lista de depósitos via API (https://run.mocky.io/v3/68cc9f8b-519b-4057-bf3c-804115e68fd4)
* Checar se os dados da lista de depósitos são válidos
  * Agência e conta de destino
  * Se a conta corrente existe no Banco Novidade (https://run.mocky.io/v3/7f0acd4b-e63d-4571-b834-c3db15f70673)
  * Se o nome está correto
  * Notificar por e-mail se o depósito foi efetuado com sucesso
  * Logar se o deposito não foi efetuado com sucesso
  * Construir uma API que consulta se o depósito foi efetuado com sucesso ou não
  
## Orientações

* Deverão ser criados 2 projetos, sendo:
  1 - Que processa o arquivo de remessa de depósito
  2 - API que realiza e consulta a situação do depósito
* Poderá ser utilizada qualquer stack de linguagem (Preferência por: .Net, Node ou GO)
* Serviço deverá ser RESTFull
* Obrigatório fazer a validação sem usar nenhum componente externo

## Como rodar

Faça o clone do projeto em qualquer lugar do seu computador com o seguinte comando abaixo:
> $ https://github.com/vagnerwentz/teste-banco-neon.git

Após isto, navegue até o projeto, e faça um build de toda a sua aplicação.
  

