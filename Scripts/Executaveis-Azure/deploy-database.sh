#!/bin/bash

# ==============================================================================
# SCRIPT 2: CRIAÇÃO DO BANCO DE DADOS AZURE SQL - CLYVO VETERINARIO
# RM: rm565206 | Região: canadacentral
# ==============================================================================

RESOURCE_GROUP="rg-clyvo-sql-rm565206"
LOCATION="canadacentral"
SQL_SERVER_NAME="sql-server-clyvo-rm565206"
DATABASE_NAME="db-clyvoveterinario"
ADMIN_USER="user-clyvo"
ADMIN_PASSWORD="Fiap@2tdsvms"

echo "=== [1/4] Criando o Grupo de Recursos para o Banco de Dados ==="
az group create --name $RESOURCE_GROUP --location $LOCATION

echo "=== [2/4] Registrando o provedor Microsoft.Sql ==="
az provider register --namespace Microsoft.Sql

echo "=== [3/4] Criando o Servidor SQL do Azure ==="
az sql server create \
  --name $SQL_SERVER_NAME \
  --resource-group $RESOURCE_GROUP \
  --location $LOCATION \
  --admin-user $ADMIN_USER \
  --admin-password $ADMIN_PASSWORD \
  --enable-public-network true

echo "=== [4/4] Criando o Banco de Dados SQL (Camada Basic) e Liberando Firewall ==="
az sql db create \
  --resource-group $RESOURCE_GROUP \
  --server $SQL_SERVER_NAME \
  --name $DATABASE_NAME \
  --service-objective Basic \
  --backup-storage-redundancy Local \
  --zone-redundant false

az sql server firewall-rule create \
  --resource-group $RESOURCE_GROUP \
  --server $SQL_SERVER_NAME \
  --name liberaGeralClyvo \
  --start-ip-address 0.0.0.0 \
  --end-ip-address 255.255.255.255

echo "=== Banco de Dados criado com sucesso! ==="