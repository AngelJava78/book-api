#!/bin/bash
source .env
echo "Creating Azure container registry: $ACR_NAME"
az acr create \
  --name "$ACR_NAME" \
  --resource-group $RG \
  --location $LOCATION \
  --sku Basic \
  --admin-enabled true

