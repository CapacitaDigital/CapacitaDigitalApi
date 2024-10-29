#!/bin/bash

# Espera o PostgreSQL estar pronto
./wait-for-it.sh postgres:5432 --timeout=60 --strict -- echo "PostgreSQL is up"

# Aplicar migrações do Entity Framework
dotnet ef database update

# Iniciar a aplicação
dotnet CapacitaDigitalApi.dll