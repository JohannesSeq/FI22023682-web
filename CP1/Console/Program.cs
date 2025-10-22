public class Numbers
{
    private static readonly double N = 25; //

    public static double Formula(double z)
    {
        return Round((z + Math.Sqrt(4 + Math.Pow(z, 2))) / 2);
    }

    public static double Recursive(double z)
    {
        return Round(Recursive(z, N) / Recursive(z, N - 1));
    }

    public static double Iterative(double z)
    {
        return Round(Iterative(z, N) / Iterative(z, N - 1));
    }

    private static double Recursive(double z, double n)
    {
        //Correcion para que coincida con la formula mencionada en el enunciado.
        return n == 0 || n == 1 ? 1 : z * Recursive(z, n - 1) + Recursive(z, n - 2);
    }

    private static double Iterative(double z, double n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        } else
        {
            double x = 1; // f(z, 0)
            double y = 1; // f(z, 1)
            double Result = 0;

            for (int i = 2; i <= n; i++)
            {
                Result = z * x + y;
                y = x;
                x = Result;
            }
            return Result;
        }
            

    }

    private static double Round(double value) //Se agrego el static ya que un metodo no estatico no puede ingresar a un metodo estatico.  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0120
    {
        return Math.Round(value, 10);
    }

    public static void Main(String[] args)
    {
        String[] metallics = [
            "Platinum", // [0]
            "Golden", // [1]
            "Silver", // [2]
            "Bronze", // [3]
            "Copper", // [4]
            "Nickel", // [5]
            "Aluminum", // [6]
            "Iron", // [7]
            "Tin", // [8]
            "Lead", // [9]
        ];
        for (var z = 0; z < metallics.Length; z++)
        {
            Console.WriteLine("\n[" + z + "] " + metallics[z]);
            Console.WriteLine(" ↳ formula(" + z + ")   ≈ " + Formula(z));
            Console.WriteLine(" ↳ recursive(" + z + ") ≈ " + Recursive(z));
            Console.WriteLine(" ↳ iterative(" + z + ") ≈ " + Iterative(z));
        }
    }
}
