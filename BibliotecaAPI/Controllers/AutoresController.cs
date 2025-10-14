using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [ApiController] //Atributo que indica que el controlador es de Web API
    [Route("api/autores")]// Se coloca la ruta en la que se encuentra el controlador
   public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        // Hereda de la clase ControllerBase que es una clase que tiene funcionalidad auxiliar que nos ayuda a trabajar

        public AutoresController(ApplicationDbContext context)
        {  
            this.context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<Autor>> Get() {


            return await context.Autores.ToListAsync();
        }

        [HttpGet("{id:int}")] // api/autores/id
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if(autor is null)
            {
                return NotFound();
            }
            else
            {
                return autor;
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")] // api/autores/id
        public async Task<ActionResult> Put(int id,Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest("Los id´s deben de coincidir");
            }
            else
            {
                context.Update(autor);
                await context.SaveChangesAsync();

                return Ok();
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var registroBorrados = await context.Autores.Where(x => x.Id == id).ExecuteDeleteAsync();

            if(registroBorrados ==0)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

            //if (autor is null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    context.Remove(autor);
            //    await context.SaveChangesAsync();
            //}
        }


    }
}
