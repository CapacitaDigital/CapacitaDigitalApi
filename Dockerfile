FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5158

ENV ASPNETCORE_URLS=http://+:5158

USER app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CapacitaDigitalApi.csproj", "./"]
RUN dotnet restore "CapacitaDigitalApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CapacitaDigitalApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CapacitaDigitalApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copie as ferramentas globais do estágio de build
COPY --from=build /root/.dotnet /root/.dotnet
ENV PATH="$PATH:/root/.dotnet/tools"

# Adicione um script de inicialização para aplicar as migrações
COPY entrypoint.sh .

# Mude para o usuário root para alterar permissões
USER root
RUN chmod +x entrypoint.sh

# Volte para o usuário app
USER app

ENTRYPOINT ["./entrypoint.sh"]