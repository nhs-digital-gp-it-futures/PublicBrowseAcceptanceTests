#!/bin/bash

ip -4 route list match 0/0 | awk '{print $3" host.docker.internal"}' >> /etc/hosts
echo "Resolved address for host.docker.internal"

if [ -n "${TEST_RESULT_DIR}" ]; then
  echo "directing tests result to '$TEST_RESULT_DIR'."
  dotnet test out/NHSDPublicBrowseAcceptanceTests.Tests.dll -v n --logger trx --results-directory "$TEST_RESULT_DIR"
else
  dotnet test out/NHSDPublicBrowseAcceptanceTests.Tests.dll -v n 
fi