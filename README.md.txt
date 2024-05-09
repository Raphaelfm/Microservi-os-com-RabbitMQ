# Microserviços com RabbitMQ - README

Este repositório contém dois microserviços, um cliente e um servidor, que se comunicam usando o RabbitMQ como sistema de mensageria. Os microserviços são desenvolvidos em C# e estão configurados para serem executados em contêineres Docker.

Você pode baixar o docker apropriado para seu uso aqui: https://www.docker.com/products/docker-desktop/

## Pré-requisitos

- Docker instalado e configurado na sua máquina ([Instruções de Instalação Docker](https://docs.docker.com/get-docker/))
- Postman instalado para testar os serviços ([Página de Download do Postman](https://www.postman.com/downloads/))

## Configuração e Execução

1. **Clonar o Repositório:**

   Clone este repositório para sua máquina local:

   ```bash
   git clone https://github.com/Raphaelfm/Microservi-os-com-RabbitMQ.git
   ```

2. **Construir os Contêineres Docker:**

   No diretório raiz do repositório, execute o comando a seguir para construir os contêineres Docker:

   ```bash
   docker-compose build
   ```

3. **Iniciar os Serviços:**

   Após a construção dos contêineres, execute o seguinte comando para iniciar os serviços:

   ```bash
   docker-compose up
   ```

   Este comando iniciará os contêineres Docker para os microserviços cliente e servidor, bem como para o RabbitMQ.

4. **Acessar os Serviços:**

   - O serviço do cliente estará acessível em `http://localhost:5001/Pagamento/pagar`.
   - O serviço do servidor estará acessível em `http://localhost:5002/Notificacao/notificar`.

## Testando os Serviços com Postman

Você pode testar os serviços usando o Postman:

1. Abra o Postman e crie uma nova requisição.
2. Defina o método como `POST`.
3. Insira o URL do serviço desejado (por exemplo, `http://localhost:5001/Pagamento/pagar` para o serviço do cliente).
4. Adicione os parâmetros necessários no corpo da requisição, se aplicável.
5. Envie a requisição e verifique a resposta do serviço.

## Parando e Removendo os Serviços

Para parar os serviços e remover os contêineres Docker, execute o seguinte comando:

```bash
docker-compose down
```

Isso encerrará todos os contêineres Docker associados aos serviços.

## Observações

- Certifique-se de que as portas necessárias (8080, 5000, 5672, 15672) estão disponíveis em sua máquina local e não estão sendo utilizadas por outros serviços.
- Certifique-se de que não há problemas de firewall que possam bloquear o tráfego nas portas utilizadas pelos serviços.
