# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Restaurar dependências
COPY MicroservicoCliente/*.csproj ./
RUN dotnet restore

# Copiar e compilar o código
COPY MicroservicoCliente/ ./
RUN dotnet publish -c Release -o out

# Estágio de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "MicroservicoCliente.dll"]
