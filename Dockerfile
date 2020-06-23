FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as BUILD
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o ./publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS RUNTIME
WORKDIR /app
COPY --from=BUILD /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet HerokuTest.dll
