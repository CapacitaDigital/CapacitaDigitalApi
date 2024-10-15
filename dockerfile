# Usa a imagem base do SDK do .NET 8.0 para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY CapacitaDigitalApi.csproj ./
RUN dotnet restore

# Copia o restante do código da aplicação para o container
COPY . .
# Compila a aplicação em modo Release e coloca os binários no diretório /out
RUN dotnet build -c Release -o /out

# Publica a aplicação em modo Release e coloca os artefatos no diretório /out
RUN dotnet publish -c Release -o /out

# Usa a imagem base do SDK do .NET 8.0 para rodar a aplicação e garantir que o Entity Framework CLI esteja disponível
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
COPY entrypoint.sh .
COPY wait-for-it.sh .

# Concede permissões de execução aos scripts de entrada
RUN chmod +x entrypoint.sh wait-for-it.sh

# Instala o Entity Framework CLI
RUN dotnet tool install --global dotnet-ef

# Adiciona o diretório de ferramentas .NET ao PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Define o ponto de entrada para o script de inicialização
ENTRYPOINT ["./entrypoint.sh"]