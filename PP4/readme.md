# Practica Programada #4

## Autor
Johannes Sequeira <br />
FI22023682

## Comandos utilizados

### Dotnet:
```
dotnet tool update --global dotnet-ef
dotnet new sln -n PP4 
dotnet new globaljson --sdk-version 8.0.414
dotnet new console -o Biblioteca
dotnet sln add Biblioteca
cd Biblioteca
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Code First:
```
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Respuestas
### ¿Cómo cree que resultaría el uso de la estrategia de Code First para crear y actualizar una base de datos de tipo NoSQL (como por ejemplo MongoDB)? ¿Y con Database First? ¿Cree que habría complicaciones con las Foreign Keys?
Cabe mencionar que el objetivo principal de Entity Framework es ser utilizado con bases de datos relacionales; sin embargo, podría adaptarse a otros tipos de bases de datos.
Dado que las bases de datos NoSQL funcionan mediante métodos distintos a las tablas, su implementación dependería en gran medida del tipo de base de datos que se utilice.
Siempre que el sistema cuente con algún identificador que actúe como clave, podrían incorporarse llaves foráneas mediante otros mecanismos, como el uso de objetos.

### ¿Cuál carácter, además de la coma (,) y el Tab (\t), se podría usar para separar valores en un archivo de texto con el objetivo de ser interpretado como una tabla (matriz)? ¿Qué extensión le pondría y por qué? Por ejemplo: Pipe (|) con extensión .pipe.
Dependiendo del tipo de datos que contengan, podría utilizarse el formato SSV (space-separated values), PSV (pipe-separated values), como se menciona en el enunciado, u otros caracteres especiales, como el ampersand (&), en el caso de un formato ASV (and-separated values).

### Referencias

Lectura de archivos CSV en C#:
> https://stackoverflow.com/questions/3507498/reading-csv-files-using-c-sharp

API fluida: configuración y asignación de propiedades y tipos:
> https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties

Introducción a las relaciones:
> https://learn.microsoft.com/en-us/ef/core/modeling/relationships

Escribir texto en un archivo:
> https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-write-text-to-a-file
