var builder = WebApplication.CreateBuilder(args);

#region area de servicios
builder.Services.AddControllers();  //Se habilita la funcionalidad de los controladores

#endregion


var app = builder.Build();


#region area d middlewares

app.MapControllers(); // Cuando llegue una peticion va a ser un controlador el que de respuesta a dicha peticion

#endregion




app.Run();
