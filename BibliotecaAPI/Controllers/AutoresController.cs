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


        [HttpGet("/listado-de-autores")]
        [HttpGet ]
        public async Task<IEnumerable<Autor>> Get() {


            return await context.Autores.ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<Autor> GetPrimerAutor()
        {


            return await context.Autores.FirstAsync();
        }

        [HttpGet("{id:int}")] // api/autores/id?incluirLibros=true  esta es cuando es [FromQuery]
        public async Task<ActionResult<Autor>> Get(int id, [FromHeader] bool incluirLibros  )
        {
            var autor = await context.Autores
                .Include(x=> x.Libros)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(autor is null)
            {
                return NotFound();
            }
            else
            {
                return autor;
            }
        }


        [HttpGet("{nombre:alpha}")] // api/autores/id
        public async Task<IEnumerable<Autor>> Get(string nombre)
        {
            return await context.Autores
                .Include(x=> x.Libros)
                .Where(x=>x.Nombre.Contains(nombre)).ToListAsync();
        }


        //[HttpGet("{parametro1}/{parametro2?}")] // api/autores/id
        //public ActionResult Get(string parametro1,string parametro2="Valor por defecto")
        //{
        //    return Ok(new {parametro1,parametro2});
        //}


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

        }


    }
}
