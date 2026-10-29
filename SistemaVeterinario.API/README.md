# Sistema Veterinário API

Este projeto é uma API RESTful desenvolvida em **ASP.NET Core** para o gerenciamento de uma clínica veterinária. O sistema permite o controle de **Tutores**, seus **Pets** e os **Veterinários** responsáveis, garantindo a integridade dos dados através de uma arquitetura em camadas e integração com banco de dados **Oracle**.

## Integrantes
* **Lucas Matsubara Reis** | RM565020
* **João Pedro Camilo** | RM562005
* **Pamella Christiny** | RM565206

## Tecnologias Utilizadas
* **ASP.NET Core 10.0**
* **Entity Framework Core** (ORM)
* **Oracle Database**
* **Swagger (OpenAPI)** para documentação

🚀 Guia Prático: Deploy do Zero no Azure Cloud Shell (Clyvo Veterinário)
Este guia cobre o processo completo de ponta a ponta: autenticação, criação dos recursos de banco de dados, clonagem do seu repositório Git e publicação da API .NET 8 no App Service.

Passo 1: Acessar o Azure Cloud Shell e Fazer Login
Abra o Portal do Azure.

Clique no ícone do Cloud Shell (>_) na barra superior direita e selecione o ambiente Bash.

Caso seja solicitado ou queira garantir que a sua sessão está autenticada, execute o comando de login:

Bash
az login
Siga as instruções na tela (abrindo a página de autenticação e inserindo o código) para conectar a sua conta.

Passo 2: Criar o Banco de Dados Azure SQL
suba ao portal o arquivo C:\Users\pamel\Desktop\Challenge-Sprint-3-CI-CD-Azure-Devops\Scripts\deploy-database.sh
e execute 

Torne o script executável, limpe quebras de linha e execute-o:

Bash
sed -i -e 's/\r$//' deploy-database.sh
chmod +x deploy-database.sh
bash deploy-database.sh
(Aguarde a finalização da criação do servidor SQL).


Passo 3: Clonar o Repositório do Projeto
Agora vamos baixar o código-fonte diretamente para o ambiente do Cloud Shell.Certifique-se de estar na sua pasta raiz do Cloud Shell:Bashcd ~

Clone o seu repositório do GitHub (substitua pela URL exata do seu repositório):   

git clone https://github.com/Portifolio-Pamella/Challenge-Sprint-3-CI-CD-Azure-Devops.git

Entre na pasta recém-criada do repositório:

cd cd ~/Challenge-Sprint-3-CI-CD-Azure-Devops/SistemaVeterinario.API

Execute o arquivo C:\Users\pamel\Desktop\Challenge-Sprint-3-CI-CD-Azure-Devops\SistemaVeterinario.API\deploy-webapp.sh

Ele está dentro da pasta SistemaVeterinario.API. para que seja encontrado com maior facilidade o arquivo executavel, já que a arquitetura do projet é em camadas e o executavel não está na raiz.

