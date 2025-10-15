using BibliotecaAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo {0} es Requerido")]
        [StringLength(150,ErrorMessage ="El campo {0} no debe de pasar los {1} caracteres")]
        [PrimeraLetraMayuscula]
        public required string Nombre { get; set; }

        public List<Libro> Libros { get; set; } = new List<Libro>();

        //[Range(18,60)]
        //public int Edad { get; set; }
        //[CreditCard]
        //public string? Tarjetacredito { get; set; }
        //[Url]
        //public string? URL { get; set; }
    }
}
