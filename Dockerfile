FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILD
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS RUNTIME
WORKDIR /app
COPY --from=BUILD /src/publish .
RUN rm /bin/sh && ln -s /bin/bash /bin/sh
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HerokuTest.dll
