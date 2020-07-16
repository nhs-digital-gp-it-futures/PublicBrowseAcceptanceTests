FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11
ENV MSBUILDSINGLELOADCONTEXT=1
WORKDIR /app
COPY ./src ./
COPY ./entrypoint.sh ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["/bin/sh", "entrypoint.sh"]