#!/bin/sh

# Força a exclusão do banco de dados sem solicitar confirmação
dotnet ef database drop --force --project /app/CapacitaDigitalApi.csproj

# Aplica as migrações do Entity Framework
dotnet ef database update --project /app/CapacitaDigitalApi.csproj

# Inicia a aplicação
dotnet CapacitaDigitalApi.dll