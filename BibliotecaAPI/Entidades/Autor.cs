using BibliotecaAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Autor :IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo {0} es Requerido")]
        [StringLength(10,ErrorMessage ="El campo {0} no debe de pasar los {1} caracteres")]
       // [PrimeraLetraMayuscula]
        public required string Nombre { get; set; }

        public List<Libro> Libros { get; set; } = new List<Libro>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre)) {
                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper()) {

                    yield return new ValidationResult("La primera letra debe ser mayuscula-por modelo",
                        new string[] {nameof(Nombre)});
                }

            }
        }

        //[Range(18,60)]
        //public int Edad { get; set; }
        //[CreditCard]
        //public string? Tarjetacredito { get; set; }
        //[Url]
        //public string? URL { get; set; }
    }
}
