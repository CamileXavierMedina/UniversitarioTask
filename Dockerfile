# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os ficheiros de projeto primeiro para otimizar o cache
COPY ["UniversitarioTask.Site/UniversitarioTask.Site.csproj", "UniversitarioTask.Site/"]
RUN dotnet restore "UniversitarioTask.Site/UniversitarioTask.Site.csproj"

# Copia o resto do código e compila
COPY . .
WORKDIR "/src/UniversitarioTask.Site"
RUN dotnet build "UniversitarioTask.Site.csproj" -c Release -o /app/build

# Publicação
FROM build AS publish
RUN dotnet publish "UniversitarioTask.Site.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configuração de porta para o Render
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "UniversitarioTask.Site.dll"]
