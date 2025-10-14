using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController] //Atributo que indica que el controlador es de Web API
    [Route("api/autores")]// Se coloca la ruta en la que se encuentra el controlador
   public class AutoresController: ControllerBase
    {
        // Hereda de la clase ControllerBase que es una clase que tiene funcionalidad auxiliar que nos ayuda a trabajar

        [HttpGet]
        public IEnumerable<Autor> Get() {


            return new List<Autor>
            {
                new Autor { Id = 1,Nombre="Juan" },
                new Autor { Id = 2,Nombre="Vianney" }
            };
        }
    }
}
