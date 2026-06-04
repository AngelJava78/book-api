#!/bin/bash
source .env
echo "Creating resource group: $RG"
az group create \
  --name $RG \
  --location $LOCATION
