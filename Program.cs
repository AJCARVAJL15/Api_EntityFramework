using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDb"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));





var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria" + dbContext.Database.IsInMemory());
});

app.MapGet("api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.PrioridadTarea== proyectoef.Models.Prioridad.media));
});


app.MapPost("api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{
    tarea.TareaId=Guid.NewGuid();
    tarea.FechaCreacion=DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>
{
    var TareaActual=dbContext.Tareas.Find(id);
    
    if(TareaActual!=null)
    {
        TareaActual.CategoriaId=tarea.CategoriaId;
        TareaActual.Titulo=tarea.Titulo;
        TareaActual.PrioridadTarea=tarea.PrioridadTarea;
        TareaActual.Descripcion=tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async([FromServices] TareasContext dbContext, [FromRoute] Guid id)=>
{
      var TareaActual=dbContext.Tareas.Find(id);

      if(TareaActual!=null){
        dbContext.Remove(TareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
      
      }

      return Results.NotFound();

});



app.Run();





