#!/bin/bash
set -e

# Aguarde o banco de dados estar disponível
until dotnet ef database update --project CapacitaDigitalApi.csproj --startup-project CapacitaDigitalApi.csproj; do
  >&2 echo "SQL Server is starting up"
  sleep 1
done

# Inicie a aplicação
exec dotnet CapacitaDigitalApi.dll