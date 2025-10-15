using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BibliotecaAPI.Validaciones
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success; //Se retorna valido ya que esta validacion la hace el attributo Required, de si viene vacia o nula
            }

            var primeraLetra = value.ToString()![0].ToString() ;  // Si no es nulo Obtiene la primera letra

            if(primeraLetra!=primeraLetra.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayuscula");
            }

            return ValidationResult.Success;
        }
    }
}
