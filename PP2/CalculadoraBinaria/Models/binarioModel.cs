using System.ComponentModel.DataAnnotations;


namespace CalculadoraBinaria.Models;

public class binarioModel
{

    //Delcaracion de las variables

    [Required(ErrorMessage="El valor no puede estar vacio.")] //Indicamos que si o si esta variable tiene que estar rellenada
    [StringLength(8, ErrorMessage = "No se puede exceder el los 8 caracteres de un Byte.")] //Indicamos que esta variable no puede exceder los 8 caracteres, evitando que sea mayor que un Byte
    [RegularExpression("^[01]+$", ErrorMessage = "El valor debe contener únicamente 0 y 1.")] //Expresion regular que no permite que se ingresen caracteres que no sean 0 o 1
    [MultiploDeDos] // Se revisa que la longitud del numero sea un multiplo de dos
    public string a { get; set; }

    [Required(ErrorMessage="El valor no puede estar vacio.")] //Indicamos que si o si esta variable tiene que estar rellenada
    [StringLength(8, ErrorMessage = "No se puede exceder el los 8 caracteres de un Byte.")] //Indicamos que esta variable no puede exceder los 8 caracteres, evitando que sea mayor que un Byte
    [RegularExpression("^[01]+$", ErrorMessage = "El valor debe contener únicamente 0 y 1.")] //Expresion regular que no permite que se ingresen caracteres que no sean 0 o 1
    [MultiploDeDos] // Se revisa que la longitud del numero sea un multiplo de dos
    public string b { get; set; }
    public string? aAndb { get; set; }
    public string? aOrb { get; set; }
    public string? aXorb { get; set; }
    public string? aSumb { get; set; }
    public string? aMultb { get; set; }

    //Metodo que se encargada de la ejecucion de los calculos
    public void ejecucion()
    {
        //Console.WriteLine("paso");
        a = Igualacion(a);
        b = Igualacion(b);
        aAndb = OperacionAnd();
        aOrb = OperacionOr();
        aXorb = OperacionXor();
        aSumb = Sum();
        aMultb = Mult();
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

    private string Sum()
    {
        string result = "";
        char sumador = '0';

        for (int i = 7; i >= 0; i--)
        {
            if (a[i] == '1' && b[i] == '1')
            {
                if (sumador == '1')
                {
                    result = "1" + result;
                    sumador = '1';
                }
                else
                {
                    sumador = '1';
                    result = "0" + result;
                }
            }
            else if (a[i] == '1' || b[i] == '1')
            {
                if (sumador == '1')
                {
                    sumador = '1';
                    result = "0" + result;
                }
                else
                {
                    sumador = '0';
                    result = "1" + result;
                }
            }
            else
            {
                if (sumador == '1')
                {
                    sumador = '0';
                    result = "1" + result;
                }
                else
                {
                    sumador = '0';
                    result = "0" + result;
                }
            }

        }
        return result;
    }

    private string Mult()
    {
        string result = "";

        string numA = ConversionDec(a);
        string numB = ConversionDec(b);

        int NumAint = int.Parse(numA);
        int NumBint = int.Parse(numB);

        int resultInt = NumAint * NumBint;
        if (resultInt > 255)
        {
            result = "00000000";
        }
        else
        {
            while (resultInt > 0)
            {
                if (resultInt % 2 == 0)
                {
                    result =  "0" + result;
                }
                else
                {
                    result = "1" + result;
                }
                resultInt /= 2;
            }
        }
        result = Igualacion(result);
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
        }
        result = resultNum.ToString();
        return result;
    }

    public string ConversionHex(string x)
    {
        string resultDec = ConversionDec(x);
        int resultDecInt = int.Parse(resultDec);


        List<String> Hexal = new List<String>();
        Hexal.Add("0");

        int c = 0;
        string result = "";

        for (int i = 0; i < resultDecInt; i++)
        {

            c++;
            string cHex = HexChar(c);

            if (c == 16)
            {
                c = 0;
                if (Hexal.Count - 1 == 0)
                {
                    Hexal.Insert(0, "1");
                }
                else
                {
                    for (int j = Hexal.Count - 1; j >= 0; j--)
                    {
                        if (Hexal[j] == "F")
                        {
                            Hexal[j] = "0";
                            if (j == 0)
                            {
                                Hexal.Insert(0, "1");
                            }

                        }
                        else
                        {
                            int valnum = HexInt(Hexal[j]);
                            valnum += 1;
                            Hexal[j] = HexChar(valnum);
                            break;
                        }
                    }
                }

            }
            else
            {
                Hexal[Hexal.Count - 1] = cHex;
            }

        }
        for (int i = 0; i < Hexal.Count; i++)
        {
            result += Hexal[i];
        }
        return result;
    }

    private string HexChar(int n)
    {
        string car = "";
        switch (n)
        {
            case 0:
                car = "0";
                break;
            case 1:
                car = "1";
                break;
            case 2:
                car = "2";
                break;
            case 3:
                car = "3";
                break;
            case 4:
                car = "4";
                break;
            case 5:
                car = "5";
                break;
            case 6:
                car = "6";
                break;
            case 7:
                car = "7";
                break;
            case 8:
                car = "8";
                break;
            case 9:
                car = "9";
                break;
            case 10:
                car = "A";
                break;
            case 11:
                car = "B";
                break;
            case 12:
                car = "C";
                break;
            case 13:
                car = "D";
                break;
            case 14:
                car = "E";
                break;
            case 15:
                car = "F";
                break;
            default:
                car = "0";
                break;
        }

        return car;
    }

private int HexInt(string h)
{
    int n = 0;

        switch (h)
        {
            case "0":
                n = 0;
                break;
            case "1":
                n = 1;
                break;
            case "2":
                n = 2;
                break;
            case "3":
                n = 3;
                break;
            case "4":
                n = 4;
                break;
            case "5":
                n = 5;
                break;
            case "6":
                n = 6;
                break;
            case "7":
                n = 7;
                break;
            case "8":
                n = 8;
                break;
            case "9":
                n = 9;
                break;
            case "A":
                n = 10;
                break;
            case "B":
                n = 11;
                break;
            case "C":
                n = 12;
                break;
            case "D":
                n = 13;
                break;
            case "E":
                n = 14;
                break;
            case "F":
                n = 15;
                break;
            default:
                n = 0;
                break;
        }
        return n;
    }


    public string ConversionOct(string x)
    {

        string resultDec = ConversionDec(x);

        int resultDecInt = int.Parse(resultDec);

        List<String> Octal = new List<String>();
        Octal.Add("0");

        int c = 0;
        string result = "";

        for (int i = 0; i < resultDecInt; i++)
        {
            c++;

            if (c == 8)
            {
                c = 0;
                if (Octal.Count - 1 == 0)
                {
                    Octal.Insert(0, "1");
                }
                else
                {
                    for (int j = Octal.Count - 1; j >= 0; j--)
                    {
                        if (Octal[j] == "7")
                        {
                            Octal[j] = "0";
                            if (j == 0)
                            {
                                Octal.Insert(0, "1");
                            }

                        }
                        else
                        {
                            int valnum = int.Parse(Octal[j]);
                            valnum += 1;
                            Octal[j] = valnum.ToString();
                            break;
                        }
                    }
                }

            }
            else
            {
                Octal[Octal.Count - 1] = c.ToString();
            }

        }

        for (int i = 0; i < Octal.Count; i++)
        {
            result += Octal[i];
        }

        return result;
    }
}