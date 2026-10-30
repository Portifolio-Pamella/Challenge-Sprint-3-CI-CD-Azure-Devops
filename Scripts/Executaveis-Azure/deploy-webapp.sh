#!/bin/bash
RESOURCE_GROUP="rg-clyvo-sites-rm565206"
LOCATION="canadacentral"
APP_SERVICE_PLAN="plan-clyvo-rm565206"
WEB_APP_NAME="clyvo-api-rm565206"

echo "=== [1/4] Garantindo Grupo de Recursos e App Service ==="
az group create --name $RESOURCE_GROUP --location $LOCATION
az appservice plan create --resource-group $RESOURCE_GROUP --name $APP_SERVICE_PLAN --location $LOCATION --sku F1 --is-linux

echo "=== [2/4] Criando o Web App Linux para .NET 8 ==="
az webapp create --resource-group $RESOURCE_GROUP --plan $APP_SERVICE_PLAN --name $WEB_APP_NAME --runtime "DOTNETCORE|8.0"

echo "=== [3/4] Publicando o projeto .NET localmente ==="
dotnet publish -c Release -o ./publish

# Cria o pacote zip com os arquivos compilados
cd publish
zip -r ../publish.zip *
cd ..

echo "=== [4/4] Realizando o Deploy do pacote ZIP no Web App Linux ==="
az webapp deploy --resource-group $RESOURCE_GROUP --name $WEB_APP_NAME --src-path publish.zip --type zip

echo "=== Deploy do Web App concluído com sucesso! ==="