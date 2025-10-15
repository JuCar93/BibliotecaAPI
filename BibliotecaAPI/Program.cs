using BibliotecaAPI.Datos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region area de servicios
builder.Services.AddControllers().AddJsonOptions(opciones=>
opciones.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);  //Se habilita la funcionalidad de los controladores


builder.Services.AddDbContext<ApplicationDbContext>(opciones=>
opciones.UseSqlServer("name=DefaultConectionCV"));

#endregion


var app = builder.Build();


#region area d middlewares

app.MapControllers(); // Cuando llegue una peticion va a ser un controlador el que de respuesta a dicha peticion

#endregion




app.Run();
