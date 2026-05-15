# ETAPA 1: Ambiente de Compilação (Usa o SDK do .NET)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo da sua máquina para o container
COPY . ./

# Restaura as dependências e compila o código para produção (O dotnet publish que falamos antes!)
RUN dotnet publish -c Release -o out

# ETAPA 2: Ambiente de Execução (Usa apenas o Runtime, mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia só os arquivos compilados da etapa 1
COPY --from=build /app/out .

# Expõe a porta que o Render vai usar
EXPOSE 8080

ENTRYPOINT ["dotnet", "UniversitarioTask.dll"]