using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("TareasDbConnectionOne"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en Memoria:" + dbContext.Database.IsSqlServer());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    //FILTRO POR PRORIDAD
    //return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == projectef.Models.Prioridad.Alta));
    
    //FILTRO INCLUYENDO CATEGORIA DETALLADA
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
    
});
app.MapPost("/api/carga", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    //FORMA 1
    await dbContext.AddAsync(tarea);
    //FORMA 2
    //await dbContext.Tareas.AddAsync(tarea);

    //NOS ASEGURAMOS QUE LOS CAMBOS SE GUARDEN
    await dbContext.SaveChangesAsync();

    return Results.Ok();
    
});

app.Run();
