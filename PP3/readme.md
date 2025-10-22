# Practica Programada #3

## Autor
Johannes Sequeira <br />
FI22023682

## Comandos de dotNet utilizados para la ejecución

```
dotnet new sln -n PP2
dotnet new mvc -o CalculadoraBinaria
dotnet sln add CalculadoraBinaria
```

## Respuestas

### ¿Es posible enviar valores en el Body (por ejemplo, en el Form) del Request de tipo **GET**?

Si bien es posible enviar valores en el _Body_ de una solicitud tipo **GET** de HTTP, no es lo recomendado ya que este tipo de solicitudes estan hechas para obtener información por parte del servidor y no enviarle información al mismo.

### ¿Qué ventajas y desventajas observa con el _Minimal API_ si se compara con la opción de utilizar _Controllers_?

Algunas ventajas que se pudieron notar a la hora de realizar un API con un _Minimal API_ son las siguientes:
- Facilidad para montar el codigo, asemejándose a opciones más sencillas como _Flask_.
- El codigo es muchísimo más sencillo para leerlo y trabajarlo.

Desventajas de programar un API con _Minimal API_:
- En un principio, la programación no está en capas, lo cual puede terminar en una recarga del codigo central e inseguridad al manejar toda la programación en un solo archivo y clase.

## Referencias

¿Qué es ```Attribute Routing``` en C#?
> https://learn.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2

Como solucionar el error del compilador ```CS8803```.
> https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/compiler-messages/cs8803

¿Comó serializar un objeto a un XML?
> https://stackoverflow.com/questions/4123590/serialize-an-object-to-xml

Ejemplos de serialización XML:
> https://learn.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization
