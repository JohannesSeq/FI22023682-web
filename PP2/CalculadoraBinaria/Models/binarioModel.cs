using System.ComponentModel.DataAnnotations;

namespace CalculadoraBinaria.Models;

public class binarioModel
{

    //Delcaracion de las variables
    [Required] //Indicamos que si o si esta variable tiene que estar rellenada
    [StringLength(8, ErrorMessage = "No se puede exceder el los 8 caracteres de un Byte.")] //Indicamos que esta variable no puede exceder los 8 caracteres, evitando que sea mayor que un Byte
    [RegularExpression("^[01]+$", ErrorMessage = "El valor debe contener únicamente 0 y 1.")] //Expresion regular que no permite que se ingresen caracteres que no sean 0 o 1
    [MultiploDeDos] // Se revisa que la longitud del numero sea un multiplo de dos
    public string a { get; set; }

    [Required] //Indicamos que si o si esta variable tiene que estar rellenada
    [StringLength(8, ErrorMessage = "No se puede exceder el los 8 caracteres de un Byte.")] //Indicamos que esta variable no puede exceder los 8 caracteres, evitando que sea mayor que un Byte
    [RegularExpression("^[01]+$", ErrorMessage = "El valor debe contener únicamente 0 y 1.")] //Expresion regular que no permite que se ingresen caracteres que no sean 0 o 1
    [MultiploDeDos] // Se revisa que la longitud del numero sea un multiplo de dos
     public string b { get; set; }
    public string aAndb {get; set;}
    public string aOrb {get; set;}
    public string aXorb {get; set;}
    public string aSumb {get; set;}
    public string aMultb {get; set;}


    //Metodo que se encargada de la ejecucion de los calculos
    public void ejecucion()
    {

        a = Igualacion(a);
        b = Igualacion(b);
        aAndb = OperacionAnd();
        aOrb = OperacionOr();
        aXorb = OperacionXor();
    } 

//Metodo que iguala la cantidad de caracteres de la entrada a 8, esto para tener mas facilidad a la hora de realizar los calculos.
    private string Igualacion(string x)
    {
        string igualado = x;

        if (x.Length < 8)
        {

            for (int i = x.Length + 1; i <= 8; i++)
                igualado = "0" + igualado;
        }

        return igualado;
    }

//Metodo que se encarga de ejecutar el calculo del AND
    private string OperacionAnd()
    {
        string result = "";
        for (int i = 0; i < 8; i++)
        {
            if (a[i] == '1')
            {
                if (b[i] == '1')
                {
                    result += "1";
                }
                else
                {
                    result += "0";
                }
            }
            else
            {
                result += "0";
            }
        }
        return result;
    }

//Metodo que se encarga de ejecutar el calculo del OR
    private string OperacionOr()
    {
        string result = "";
        for (int i = 0; i < 8; i++)
        {
            if (a[i] == '1')
            {
                result += "1";

            }
            else if (b[i] == '1')
            {
                result += "1";
            }

            else
            {
                result += "0";
            }
        }
        return result;
    }

    private string OperacionXor()
    {
        string result = "";

        for (int i = 0; i < 8; i++)
        {
            if (a[i] != b[i])
            {
                result += "1";
            }
            else
            {
                result += 0;
            }
        }

        return result;
    }

    private string Sum(string a, string b)
    {
        string result = "";
        return result;        
    }

    private string Mult(string a, string b)
    {
        string result = "";
        return result;        
    }
    public string ConversionDec(string x)
    { 
        string result = "";
        int resultNum = 0;
        int indice = 1;
        int c = 0;
        
        for (int i = 7; i >= 0; i--)
        {
            if (x[i] == '1')
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            resultNum += indice * c; 
            indice = 2 * indice;
            Console.WriteLine(resultNum);
        }
        result = resultNum.ToString();
        return result;
    }

    private string ConversionHex(string a, string b)
    {
        string result = "";
        return result;
    }

    private string ConversionOct(string x)
    {
        string result = "";
        int resultNum = 0;
        int indice = 1;
        int c = 0;
        
        for (int i = 7; i >= 0; i--)
        {
            if (x[i] == '1')
            {
                c = 1;
            }
            else
            {
                c = 0;
            }
            resultNum += indice * c; 
            indice = 2 * indice;
            Console.WriteLine(resultNum);
        }
        result = resultNum.ToString();
        return result;   
    }        
}