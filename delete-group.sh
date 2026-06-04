#!/bin/bash
source .env
echo "Deleting group: $RG"
az group delete --name "$RG" --yes
