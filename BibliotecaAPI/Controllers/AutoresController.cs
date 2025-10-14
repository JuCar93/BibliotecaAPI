using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController] //Atributo que indica que el controlador es de Web API
    [Route("api/autores")]// Se coloca la ruta en la que se encuentra el controlador
   public class AutoresController: ControllerBase
    {
        // Hereda de la clase ControllerBase que es una clase que tiene funcionalidad auxiliar que nos ayuda a trabajar

        [HttpGet]
        public string Get() {
            return "Autores";
        }
    }
}
