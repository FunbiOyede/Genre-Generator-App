tag=$1
ImageName=$2


docker tag ${ImageName} ${ImageName}:${tag}

docker push ${ImageName}:${tag}
