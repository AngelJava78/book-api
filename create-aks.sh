#!/bin/bash
source .env
echo "Creating Azure Kubernetes Service: $AKS_NAME"
az aks create \
  --name "$AKS_NAME" \
  --resource-group "$RG" \
  --location $LOCATION \
  --node-count 1 \
  --node-vm-size "$VM_SIZE" \
  --nodepool-name agentpool \
  --vm-set-type VirtualMachineScaleSets \
  --load-balancer-sku standard \
  --enable-managed-identity \
  --network-plugin azure \
  --no-ssh-key \
  --attach-acr "$ACR_NAME"
