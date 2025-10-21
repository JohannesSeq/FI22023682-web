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
app.MapPost("/include/{position:int}", ( [FromRoute]int position, [FromQuery]string value, [FromForm] string text, [FromHeader]bool xml = false ) =>
{
    //Validacion del texto
    if (text.Length <= 0)
    {
         var json = new
        {
            Error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);       
    } 
    //Validaciones de los datos ingresados
    else if (value == "")
    {
        var json = new
        {
            Error = "'value' cannot be empty"
        };
        return Results.BadRequest(json);

    }
    else if (position < 0)
    {
        var json = new
        {
            Error = "'position' must be 0 or higher"
        };
        return Results.BadRequest(json);

    }
    else
    {
        try
        {
            String textPrev = text;
            if (position > text.Length)
            {
                text += value;
            }
            else
            {
                text = text.Insert(position, value);
            }

            if (xml)
            {
                var xmlout = new ResultXML { Ori = textPrev, New = text };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { Ori = textPrev, New = text };
                return Results.Ok(json);
            }

        }
        catch
        {
            var json = new
            {
                Error = "Cannot process your request."
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
            Error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    //Validaciones de los datos ingresados
    else if (value == "")
    {
        var json = new
        {
            Error = "'value' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    else if (length < 0)
    {
        var json = new
        {
            Error = "'length' must be 0 or higher"
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
                var xmlout = new ResultXML { Ori = textPrev, New = newText };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { Ori = textPrev, New = newText };
                return Results.Ok(json);
            }
    
        }
        catch
        {

            var json = new
            {
                Error = "Cannot process your request."
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
            Error = "'text' cannot be empty"
        };
        return Results.BadRequest(json);
    }
    //Validaciones de los datos ingresados
    else if (length < 0)
    {
        var json = new
        {
            Error = "'length' must be 0 or higher"
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
                var xmlout = new ResultXML { Ori = textPrev, New = newText };

                var xmlSerializer = new XmlSerializer(typeof(ResultXML));
                using var StringWriter = new StringWriter();

                xmlSerializer.Serialize(StringWriter, xmlout);
                return Results.Content(StringWriter.ToString(), "application/xml");

            }
            else
            {
                var json = new { Ori = textPrev, New = newText };
                return Results.Ok(json);
            }
    
        }
        catch
        {

            var json = new
            {
                Error = "Cannot process your request."
            };
            return Results.BadRequest(json);

        }
    }
}).DisableAntiforgery();


app.UseHttpsRedirection();

app.Run();
