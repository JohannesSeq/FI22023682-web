using Microsoft.AspNetCore.Mvc; //Libreria necesaria para el error CS0246
using System.Xml.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var list = new List<object>();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapPost("/", ([FromHeader]bool xml = false) =>
{
    if (xml)
    {
        var xmlSerializer = new XmlSerializer(list.GetType());
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, list);
        return Results.Content(stringWriter.ToString(), "application/xml");
    }
    else
    {
       return Results.Ok(list);
    }
    
});

app.MapPut("/", ([FromForm] int quantity, [FromForm] string type) =>
{
    var random = new Random();

    if (quantity <= 0)
    {
        var json = new
        {
            Error = "'quantity' must be higher than zero"
        };

        return Results.BadRequest(json);
    }
    else
    {
        if (type == "int")
        {
            for (; quantity > 0; quantity--)
            {
                list.Add(random.Next());
            }
            return Results.Ok();
        }
        else if (type == "float")
        {
            for (; quantity > 0; quantity--)
            {
                list.Add(random.NextSingle());
            }
                return Results.Ok();
        }
        else
        {
            var json = new
            {
                Error = "'type' must be int or float"
            };
            return Results.BadRequest(json);
        }

    }


}).DisableAntiforgery();

app.MapDelete("/", ([FromForm] int quantity) =>
{
    if (quantity <= 0)
    {
        var json = new
        {
            Error = "'quantity' must be higher than zero"
        };

        return Results.BadRequest(json);
    } else if (list.Count == 0)
    {
        var json = new
        {
            Error = "The number list is empty"
        };
        return Results.BadRequest(json);       
    }
    else
    {
        for (; quantity > 0; quantity--)
        {
            list.RemoveAt(0);
        }
        return Results.Ok();
    }


}).DisableAntiforgery();

app.MapPatch("/", () =>
{
    list = new List<object>();
    return Results.Ok();
});

app.Run();
