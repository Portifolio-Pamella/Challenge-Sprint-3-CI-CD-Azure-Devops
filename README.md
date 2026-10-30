# Sistema Veterinário API - Clyvo

## Integrantes
*   Felipe Ribeiro Salles de Camargo | RM565224
*   João Pedro Pereira Camilo | RM562005
*   Lucas Matsubara Reis | RM565020
*   Pamella Christiny Chaves Brito | RM565206 (RM Principal)

---

## Descrição da Solução
Esta aplicação consiste numa API RESTful desenvolvida para gerir os dados de uma clínica veterinária. O sistema permite o cadastro e consulta de clientes, animais, bem como o registo de atendimentos e histórico médico.

A solução foi arquitetada seguindo boas práticas de desenvolvimento e, através deste repositório, implementámos um fluxo automatizado de Integração Contínua (CI) e Deploy Contínuo (CD) utilizando o Azure DevOps.

**Stack Tecnológica:**
*   **Linguagem:** C#
*   **Framework:** .NET 8 (ASP.NET Core)
*   **Arquitetura:** Monolítica com separação de camadas (API, Application, Domain, Infrastructure)
*   **Base de Dados (NoSQL):** MongoDB (hospedado no MongoDB Atlas)
*   **Testes:** xUnit (Testes Unitários)
*   **DevOps e CI/CD:** Azure Pipelines (YAML)
*   **Hosting:** Azure App Service (Linux)

---

## Links do Projeto
*   **Link do Vídeo de Apresentação:** `[Adicionar link do vídeo aqui]`
*   **Link do Projeto no Azure DevOps:** `[Adicionar link do board/repositório no Azure DevOps aqui]`

---

## Arquitetura do Sistema
A imagem abaixo ilustra a arquitetura da solução e o fluxo das esteiras de CI/CD implementadas no Azure DevOps, desde o commit do desenvolvedor até o deploy no Azure App Service.

![Diagrama da Arquitetura e Fluxo CI/CD](Scripts/img-Arquitetura/Arquitetura%20e%20CI_CD%20do%20Sistema%20Veterinário.png)

---

## Estrutura do Repositório (Pasta Scripts)
A pasta `Scripts` contém artefactos auxiliares, documentação e scripts de infraestrutura utilizados no projeto e no processo de DevOps.

Abaixo está a descrição detalhada do conteúdo de cada subpasta:

### 1. `database/`
Contém scripts relacionados à base de dados.
*   `create_banco.sql`: Script SQL para a criação inicial da estrutura da base de dados (caso aplicável ao contexto relacional do projeto ou para fins de documentação da modelagem).

### 2. `Executaveis-Azure/`
Contém scripts de automação (Bash) para deploy de recursos na Azure via CLI.
*   `deploy-database.sh`: Script para automatizar o deploy ou atualização da base de dados na nuvem.
*   `deploy-webapp.sh`: Script para automatizar o provisionamento ou deploy da aplicação (Web App) no Azure App Service.

### 3. `img-Arquitetura/`
Contém os diagramas visuais do projeto.
*   `Arquitetura e CI_CD do Sistema Veterinário.png`: Diagrama que representa a infraestrutura da solução e o pipeline de CI/CD.

### 4. `Json-Testes-API/`
Contém ficheiros JSON utilizados para testes manuais ou automatizados dos endpoints da API.
*   `posts.json`: Massa de dados de exemplo (formato JSON) para simular o cadastro de novos atendimentos ou pacientes na API (pode ser importado em ferramentas como Postman ou Insomnia).

---

## Configuração e Deploy (CI/CD)

O deploy deste projeto é totalmente automatizado pelo **Azure Pipelines**. O ficheiro de configuração encontra-se na raiz do repositório com o nome `azure-pipelines.yml`.

O pipeline é dividido em dois estágios:

1.  **Build e Testes (CI):**
    *   Restaura as dependências NuGet.
    *   Compila a solução .NET 8.
    *   Executa os testes unitários (xUnit).
    *   Publica o artefacto (ficheiro `.zip` da API).
2.  **Deploy no Azure (CD):**
    *   Descarrega o artefacto gerado no estágio anterior.
    *   Faz o deploy para o Azure Web App (`clyvo-api-rm565206`) utilizando a tarefa `AzureWebApp@1` (ZIP Deploy).

Para configurar o ambiente no Azure, certifique-se de configurar as *Application Settings* no portal do Azure com a *Connection String* do MongoDB Atlas.