#!/bin/bash

# ==============================================================================
# SCRIPT 1: DEPLOY DO WEB APP (.NET 8) - CLYVO VETERINARIO
# RM: rm565206 | Região: canadacentral
# ==============================================================================

# 1. Variáveis de Configuração
RESOURCE_GROUP="rg-clyvo-sites-rm565206"
LOCATION="canadacentral"
APP_SERVICE_PLAN="plan-clyvo-rm565206"
WEB_APP_NAME="clyvo-api-rm565206"

echo "=== [1/5] Registrando provedor Microsoft.Web ==="
az provider register --namespace Microsoft.Web

echo "=== [2/5] Criando o Grupo de Recursos ==="
az group create --name $RESOURCE_GROUP --location $LOCATION

echo "=== [3/5] Criando o Plano do App Service (Escala F1 Gratuita) ==="
az appservice plan create \
  --resource-group $RESOURCE_GROUP \
  --name $APP_SERVICE_PLAN \
  --location $LOCATION \
  --sku F1 \
  --is-linux

echo "=== [4/5] Criando o Web App para .NET 8 ==="
az webapp create \
  --resource-group $RESOURCE_GROUP \
  --plan $APP_SERVICE_PLAN \
  --name $WEB_APP_NAME \
  --runtime "DOTNETCORE|8.0"

echo "=== [5/5] Realizando o Deploy da API .NET 8 ==="
# Localiza e entra na pasta do projeto onde está a API (mesmo se estiver dentro de subpastas)
PROJECT_DIR=$(find . -type d -name "SistemaVeterinario.API" | head -n 1)

if [ -d "$PROJECT_DIR" ]; then
    cd "$PROJECT_DIR"
    echo "Entrando na pasta do projeto: $(pwd)"
    az webapp up \
      --resource-group $RESOURCE_GROUP \
      --location $LOCATION \
      --plan $APP_SERVICE_PLAN \
      --name $WEB_APP_NAME \
      --sku F1 \
      --logs
else
    echo "ERRO: A pasta 'SistemaVeterinario.API' não foi encontrada neste diretório nem abaixo dele."
    exit 1
fi

echo "=== Deploy do Web App concluído com sucesso! ==="