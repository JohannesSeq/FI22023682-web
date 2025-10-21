using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using System.Xml.XPath;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Variable de oración la cual va a ser utilizada por el Api
//string text = "This is just a test that shows how the 'include' endpoint works over some text of this sentence";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Endpoint: /
//Endpoint encargado de la redireccion a la documentacion del API en Swagger.
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

//Endpoint: /include
//Endpoint encargado de incluir una nueva palabra a la text. Recibe dos parametros, la palabra y el indice donde vamos a colocar la misma.
app.MapPost("/include/{index:int}", ( [FromRoute]int index, [FromQuery]string value, [FromForm] string text, [FromHeader]bool xml = false ) =>
{
    //Validacion del texto
    if (text.Length <= 0)
    {
         var json = new
        {
            error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);       
    } 
    //Validaciones de los datos ingresados
    else if (value == "")
    {
        var json = new
        {
            error = "'value' cannot be empty"
        };
        return Results.BadRequest(json);

    }
    else if (index < 0)
    {
        var json = new
        {
            error = "'position' must be 0 or higher"
        };
        return Results.BadRequest(json);

    }
    else
    {
        try
        {
            String textPrev = text;
            if (index > text.Length)
            {
                text += value;
            }
            else
            {
                text = text.Insert(index, value);
            }

            if (xml)
            {
                var xmlout = new ResultXML { ori = textPrev, newSen = text };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { ori = textPrev, newSen = text };
                return Results.Ok(json);
            }

        }
        catch
        {
            var json = new
            {
                error = "Cannot process your request."
            };
            return Results.BadRequest(json);

        }

    }

}).DisableAntiforgery();

app.MapPut("/replace/{length:int}", ([FromRoute] int length, [FromQuery] string value, [FromForm] string text, [FromHeader] bool xml = false) =>

{

    String textPrev = text;

    //Validacion del texto
    if (text.Length <= 0)
    {
        var json = new
        {
            error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    //Validaciones de los datos ingresados
    else if (value == "")
    {
        var json = new
        {
            error = "'value' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    else if (length < 0)
    {
        var json = new
        {
            error = "'length' must be 0 or higher"
        };
        return Results.BadRequest(json);

    } else
    {
        try
        {
            String word = "";
            String newText = "";

            for (int i = 0; i < text.Length; i++)
            { 
                if (text[i] == ' ')
                {

                    if (word.Length == length)
                    {
                        word = value;
                    }

                    newText = newText + word + " ";
                    word = "";

                }
                else if (i == text.Length - 1)
                {
                    word += text[i].ToString();

                    if (word.Length == length)
                    {
                        word = value;
                    }

                    newText = newText + word;
                }

                else
                {
                    word += text[i].ToString();
                }
            }

            if (xml)
            {
                var xmlout = new ResultXML { ori = textPrev, newSen = newText };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { ori = textPrev, newSen = newText };
                return Results.Ok(json);
            }
    
        }
        catch
        {

            var json = new
            {
                error = "Cannot process your request."
            };
            return Results.BadRequest(json);

        }
    }
}).DisableAntiforgery();


app.MapDelete("/erase/{length:int}", ([FromRoute] int length, [FromForm] string text, [FromHeader] bool xml = false) =>

{

    String textPrev = text;

    //Validacion del texto
    if (text.Length <= 0)
    {
        var json = new
        {
            error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    //Validaciones de los datos ingresados
    else if (length < 0)
    {
        var json = new
        {
            error = "'length' must be 0 or higher"
        };
        return Results.BadRequest(json);

    } else
    {
        try
        {
            String word = "";
            String newText = "";

            for (int i = 0; i < text.Length; i++)
            { 
                if (text[i] == ' ')
                {

                    if (word.Length == length)
                    {
                        word = "";
                    }
                    else
                    {
                        newText = newText + word + " ";
                        word = "";
                    }

                }
                else if (i == text.Length - 1)
                {
                    word += text[i].ToString();

                    if (word.Length == length)
                    {
                        word = "";
                    }

                    newText = newText + word;
                }

                else
                {
                    word += text[i].ToString();
                }
            }

            if (xml)
            {
                var xmlout = new ResultXML { ori = textPrev, newSen = newText };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { ori = textPrev, newSen = newText };
                return Results.Ok(json);
            }
    
        }
        catch
        {

            var json = new
            {
                error = "Cannot process your request."
            };
            return Results.BadRequest(json);

        }
    }
}).DisableAntiforgery();


app.UseHttpsRedirection();

app.Run();
