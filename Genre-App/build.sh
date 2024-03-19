#!/bin/bash

set -e

HOST_PORT=3000
CONTAINER_PORT=80
CONTAINER_NAME=genre-app
IMAGE_NAME=funbi/genre-app
ENV=Development

echo "Building docker image for lofi app."

build_image() {
    echo "Building docker image...."
    docker build --platform linux/arm64 -t ${IMAGE_NAME} .

    IMAGE_NAME=$(docker images --format "{{.Repository}}" | head -1)

    echo "Image name is - ${IMAGE_NAME}"

    docker inspect ${IMAGE_NAME} -f "Image OS Details - {{.Architecture}}, {{.Os}}"
}

# kill and delete containers

kill_container() {
    # checks running container
    container_id=$(docker ps -aq --filter "name=${CONTAINER_NAME}")

    echo "Container ID is ${container_id}"

    if [[ -n "${container_id}" ]]; then
        docker kill ${container_id}
        echo "Container Port -  ${CONTAINER_PORT} is stopped"
        docker rm ${container_id}
        echo "Container - ${container_id} is deleted"
    else
        echo "No containers are running on Port - ${CONTAINER_PORT}"
    fi

}

start_container() {

    echo "Starting new docker container...."

    CONTAINER_ID=$(docker run -d -p ${HOST_PORT}:${CONTAINER_PORT} -e ASPNETCORE_ENVIRONMENT=${ENV} --name ${CONTAINER_NAME} ${IMAGE_NAME})
    container_status=$(docker container inspect -f '{{.State.Status}}' ${CONTAINER_ID})
    echo "Container status - ${container_status}"

    if [[ ${container_status} == "running" ]]; then
        echo "Container up and running"

    else
        echo "Container not running"
        exit 1

    fi

}


build_image

kill_container

start_container

