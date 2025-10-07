# Practica Programada #2

## Autor
Johannes Sequeira <br />
FI22023682

## Comandos de dotNet utilizados para la ejecución

```
dotnet new sln -n PP2
dotnet new mvc -o CalculadoraBinaria
dotnet sln add .\CalculadoraBinaria\
```

## Respuestas

### Cuál es el número que resulta al multiplicar, si se introducen los valores máximos permitidos en a y b? Indíquelo en todas las bases (binaria, octal, decimal y hexadecimal).
El número máximo permitido al multiplicar un byte por otro byte es 65025 (10000000000001001 en binario), pero, debido a que este número excede los 8 bits permitidos, el resultado es truncado, haciendo que los valores varíen en las diferentes notaciones:

| Base                 | Numero         |
| :------------------- | :------------- |
| Decimal              |    9           |
| Octal                |    11          |
| Binario              |    00001001    |
| Hexadecimal          |                |

Como nota, el codigo presentado esta capado para no admitir multiplicaciones mayores a 255 para evitar numeros fuera de rango.

### ¿Es posible hacer las operaciones en otra capa? Si sí, ¿en cuál sería?

## Referencias

Validacion de datos en C#:
> https://learn.microsoft.com/es-es/aspnet/mvc/overview/older-versions-1/models-data/validation-with-the-data-annotation-validators-cs


Como hacer una validacion de varias longitudes:
> https://stackoverflow.com/questions/16423597/validate-a-string-to-be-one-of-two-lengths

Ayúdame a hacer un hazme un regular expression en C# para un annotation que admita strings solamente compuestos por 0 y 1
