
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
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update

https://stackoverflow.com/questions/3507498/reading-csv-files-using-c-sharp
https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
https://learn.microsoft.com/en-us/ef/core/modeling/relationships
https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
