#!/bin/bash

additionalDotnetArgs=""

ip -4 route list match 0/0 | awk '{print $3" host.docker.internal"}' >> /etc/hosts
echo "Resolved address for host.docker.internal"

if [ -n "${TEST_RESULT_DIR}" ]; then
  echo "Directing test results to '$TEST_RESULT_DIR'"
  additionalDotnetArgs+="--logger trx --results-directory $TEST_RESULT_DIR "
fi

if [ -n "${TEST_FILTER}" ]; then
  echo "Running only tests annotated with '@$TEST_FILTER'"
  additionalDotnetArgs+="--filter TestCategory=$TEST_FILTER "
fi

cmd="dotnet test out/NHSDPublicBrowseAcceptanceTests.Tests.dll -v n $additionalDotnetArgs"
echo -e "\nRunning '$cmd' \n"
eval $cmd
