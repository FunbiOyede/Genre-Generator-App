echo "****** Deploying via Helm Charts ******"


#check if release is installed and delete
releaseName=$1
chartFile=$2

result=$(helm install ${releaseName} ${chartFile})

echo "${result}"



