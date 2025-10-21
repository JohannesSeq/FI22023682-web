var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Variable de oración la cual va a ser utilizada por el Api
string oracion = "This is just a test that shows how the 'include' endpoint works over some text of this sentence";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoint: /
//Endpoint encargado de la redireccion a la documentacion del API en Swagger.
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));


//Endpoint de Get solamente para probar el estado de la oracion, voy a ser eliminado en las futuras versiones
app.MapGet("/read", () => oracion);

//Endpoint: /include
//Endpoint encargado de incluir una nueva palabra a la oracion. Recibe dos parametros, la palabra y el indice donde vamos a colocar la misma.
app.MapPost("/include/{index:int}", (int index, string value) =>
{
    String oracionPrev = oracion;

    //Validaciones de los datos ingresados
    if (value == "")
    {
        return Results.BadRequest("'value' cannot be empty");
    }
    else if (index < 0)
    {
        return Results.BadRequest("'position' must be 0 or higher");

    } else if (index > oracion.Length)
    {
        return Results.BadRequest("'position' must not exceed current sentence lenght");
    }
    else
    {
        try
        {
            oracion = oracion.Insert(index, value);

            return Results.Ok(oracion);

        }
        catch
        {
            return Results.BadRequest("Unexpected error handling your request.");

        }

    }

});

app.UseHttpsRedirection();




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
