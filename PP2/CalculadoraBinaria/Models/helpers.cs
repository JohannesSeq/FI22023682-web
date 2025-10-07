using System.ComponentModel.DataAnnotations;

namespace CalculadoraBinaria.Models;

public class MultiploDeDos : ValidationAttribute
{
    public MultiploDeDos() { }
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }
        else
        {
        var typedvalue = (string)value;
        if (typedvalue.Length % 2 == 0)
        {
            return true;
        }
        else
        {
            ErrorMessage = "El valor debe de ser múltiplo de 2.";
            return false;
         }            
        }


        
    }
}