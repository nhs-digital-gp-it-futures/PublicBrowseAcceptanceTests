FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11
ENV MSBUILDSINGLELOADCONTEXT=1 HUBURL=http://host.docker.internal:4444/wd/hub BROWSER=chrome SERVERURL=host.docker.internal,1450 STORAGE_CONNECTION_STRING="AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://host.docker.internal:10000/devstoreaccount1;QueueEndpoint=http://host.docker.internal:10001/devstoreaccount1;TableEndpoint=http://host.docker.internal:10002/devstoreaccount1;"
WORKDIR /app
COPY ./src ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "test", "out/NHSDPublicBrowseAcceptanceTests.Tests.dll"]