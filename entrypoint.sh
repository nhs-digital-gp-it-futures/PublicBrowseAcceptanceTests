#!/bin/sh

ip -4 route list match 0/0 | awk '{print $3" host.docker.internal"}' >> /etc/hosts
echo "Resolved address for host.docker.internal"

dotnet test out/NHSDPublicBrowseAcceptanceTests.Tests.dll -v n
