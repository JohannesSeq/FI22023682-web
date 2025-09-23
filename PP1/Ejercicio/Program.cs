

//Metodo #1 Validar asendentemente desde 1 hasta Max
List <int> SumFor(int n)
{
    List<int> result = new List<int> {0,0,0,0};

    int Max = 2147483647;
    int indice = n;
    int suma = 0;

//Suma asendente
    while (suma < Max && suma >= 0)
    {

        if (suma < Max && suma > 0)
        {
            result[0] = suma;
            result[1] = indice - 1;
        }

        suma = indice * (indice + 1) / 2;
        //Console.WriteLine("suma:" + suma + " ; indice:" + indice);  //linea debug
        indice++;

    }

    suma = 0;
    indice = Max;

    //suma desentente
    while (suma < 1)
    {
        indice--;
        suma = indice * (indice - 1) / 2;

        result[2] = suma;
        result[3] = indice - 1;

        //Console.WriteLine("suma:" + suma + " ; indice:" + indice);  //linea debug

    }


    return result;

}

List <int> SumIte(int n)
{
    List<int> result = new List<int> {0,0,0,0};

    int indice = n;
    int suma = 0;

//Suma asendente
    while (suma < int.MaxValue && suma >= 0)
    {

        if (suma < int.MaxValue && suma > 0)
        {
            result[0] = suma;
            result[1] = indice -1 ;
        }

        suma += indice;
        //Console.WriteLine("suma:" + suma + " ; indice:" + indice);  //linea debug
        indice++;

    }



    suma = 1;
    indice = int.MaxValue;

    //suma desentente; Profe muy honestamente no se como hacer que me de igual que el enunciado
    while (suma < 0)
    {
        Console.WriteLine("suma:" + suma + " ; indice:" + indice);  //linea debug

        suma = indice - suma;
        indice--;
        result[2] = suma;
        result[3] = indice;
    }
    return result;

}



//Ejecucion visible en el dotnet run
List<int> SumaFormula = SumFor(1);

Console.WriteLine(" SumFor:");
Console.WriteLine("        From 1 to Max -> n: " + SumaFormula[1] + " -> sum: " + SumaFormula[0]);
Console.WriteLine("        From Max to 1 -> n: "  + SumaFormula[3] + " -> sum: " + SumaFormula[2]);

List<int> SumaIterativa = SumIte(1);

Console.WriteLine(" SumIte:");
Console.WriteLine("        From 1 to Max -> n: " + SumaIterativa[1] + " -> sum: " + SumaIterativa[0]);
Console.WriteLine("        From Max to 1 -> n: " + SumaIterativa[3] + " -> sum: " + SumaIterativa[2]);