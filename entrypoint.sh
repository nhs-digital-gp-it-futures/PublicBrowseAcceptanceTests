#!/bin/sh

PBHOSTURL=$(echo "$PBURL" | cut -c9-)
echo "51.11.46.27   $PBHOSTURL" >> /etc/hosts 
echo "Resolved address for $PBURL"
ip -4 route list match 0/0 | awk '{print $3" host.docker.internal"}' >> /etc/hosts
echo "Resolved address for host.docker.internal"

dotnet test out/NHSDPublicBrowseAcceptanceTests.Tests.dll
