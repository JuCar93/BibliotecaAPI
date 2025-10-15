using BibliotecaAPI.Datos;
using BibliotecaAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/Libros")]
    public class LibrosController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await context.Libros
                .Include(x=>x.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (libro is null) { 
            
                return NotFound();
            }
            else
            {

                return libro;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {

            var existeAutor=await context.Autores.AnyAsync(x=> x.Id == libro.AutorId);

            if (!existeAutor) {

                return BadRequest($"El autor de id {libro.AutorId} no existe");
            }


            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,Libro libro)
        {
            if (libro.Id != id)
            {
                return BadRequest("Los ids no coinciden");
            }

            var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            if (!existeAutor)
            {

                return BadRequest($"El autor de id {libro.AutorId} no existe");
            }

            context.Update(libro);
                await context.SaveChangesAsync();
                return Ok();
            
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var librosBorrados = await context.Libros.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (librosBorrados == 0)
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
