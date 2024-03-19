echo "****** Deploying via Helm Charts ******"


#check if release is installed and delete
releaseName=$1
chartFile=$2
env=$3

if [[ ${env} == "Production" ]]; then
    result=$(helm install ${releaseName} ${chartFile})

else
    result=$(helm install  ${releaseName} ${chartFile} --dry-run --debug)
fi

echo "${result}"



