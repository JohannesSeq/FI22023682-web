
Comandos utilizados

Dotnet:
dotnet tool update --global dotnet-ef
dotnet new sln -n PP4 
dotnet new globaljson --sdk-version 8.0.414
dotnet new console -o Biblioteca
dotnet sln add Biblioteca
cd Biblioteca
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design

Code First:
dotnet ef migrations add InitialCreate