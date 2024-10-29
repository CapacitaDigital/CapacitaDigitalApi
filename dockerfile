# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de projeto e restaurar as dependências
COPY ["CapacitaDigitalApi/CapacitaDigitalApi.csproj", "CapacitaDigitalApi/"]
RUN dotnet restore "CapacitaDigitalApi/CapacitaDigitalApi.csproj"

# Copiar o restante dos arquivos e compilar a aplicação
COPY . .
WORKDIR "/src/CapacitaDigitalApi"
RUN dotnet build "CapacitaDigitalApi.csproj" -c Release -o /app/build

# Publicar a aplicação
RUN dotnet publish "CapacitaDigitalApi.csproj" -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
COPY entrypoint.sh .
COPY wait-for-it.sh .

EXPOSE 8080

# Concede permissões de execução aos scripts de entrada
RUN chmod +x entrypoint.sh wait-for-it.sh

# Instala o Entity Framework CLI
RUN dotnet tool install --global dotnet-ef

# Adiciona o diretório de ferramentas .NET ao PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Definir a variável de ambiente para a string de conexão do PostgreSQL
ENV ConnectionStrings__DefaultConnection="Host=postgres;Database=capacitadigital;Username=jjmt;Password=@Sql21301"

# Comando de entrada para iniciar a aplicação
ENTRYPOINT ["./entrypoint.sh"]