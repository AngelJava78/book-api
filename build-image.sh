#!/bin/bash
source .env
echo "Building and pushing image: $ACR_NAME.azurecr.io/$IMG_NAME:$IMG_VERSION"
az acr build \
  --registry "$ACR_NAME" \
  --resource-group "$RG" \
  --image "$ACR_NAME.azurecr.io/$IMG_NAME:$IMG_VERSION" \
  --file "$DOCKERFILE_PATH" "$IMG_NAME"
