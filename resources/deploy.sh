# #!/bin/bash

# set -e

# deployment_name=genre-app-deployment
# service_name=genre-app-service


# # check if deployment exist

# deployment=$(kubectl get deployments --field-selector metadata.name=${deployment_name})

# service=$(kubectl get services --field-selector metadata.name=${service_name})

# if [[ -n deployment && -n service ]]; then

#     echo "Deleting Deployments and Services"

#     kubectl delete deployments ${deployment_name}
#     kubectl delete service ${service_name}

# else
#     echo "Deployment and Service do not exist"
# fi


# Create new deployment

kubectl create -f ./genre-app-deployment.yaml
kubectl create -f ./genre-app-service.yaml


