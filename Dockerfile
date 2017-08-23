FROM microsoft/aspnetcore-build as build-env

WORKDIR /app

# copy everything else and build
COPY . .
RUN dotnet restore ContinuousIntegrationHelloWorld.Tests/*.csproj
RUN dotnet test -c Release ContinuousIntegrationHelloWorld.Tests/*.csproj

# build runtime image
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=build-env /app/ContinuousIntegrationHelloWorld/bin/Release/netcoreapp2.0/ .
ENTRYPOINT ["dotnet", "ContinuousIntegrationHelloWorld.dll"]