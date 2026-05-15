# Estágio de compilação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia e restaura as dependências
# Certifica-te de que o caminho da pasta está correto (UniversitarioTask.Site)
COPY ["UniversitarioTask.Site/UniversitarioTask.Site.csproj", "UniversitarioTask.Site/"]
RUN dotnet restore "UniversitarioTask.Site/UniversitarioTask.Site.csproj"

# Copia o restante do código
COPY . .
WORKDIR "/src/UniversitarioTask.Site"

# Compila o projeto em modo Release
RUN dotnet build "UniversitarioTask.Site.csproj" -c Release -o /app/build

# Publica os ficheiros necessários
FROM build AS publish
RUN dotnet publish "UniversitarioTask.Site.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final para rodar no Render
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Porta padrão que o Render espera para serviços Web
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "UniversitarioTask.Site.dll"]
