using BibliotecaAPI.Entidades;

namespace BibliotecaAPI
{
    public class RepositorioValores
    {

        public IEnumerable<Valor> ObtenerValores()
        {
            return new List<Valor>
            {
                new Valor { id = 1, Nombre = "Valor 1" },
                new Valor { id = 2, Nombre = "Valor 2" }

            };
        }
    }
}
