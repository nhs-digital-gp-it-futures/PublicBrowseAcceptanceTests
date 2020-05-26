FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11
ENV MSBUILDSINGLELOADCONTEXT=1 HUBURL=http://host.docker.internal:4444/wd/hub BROWSER=chrome SERVERURL=host.docker.internal,1450
WORKDIR /app
COPY ./src ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "test", "out/NHSDPublicBrowseAcceptanceTests.Tests.dll"]