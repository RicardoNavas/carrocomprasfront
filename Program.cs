using BackendProductos.Repositorios;
using BackendProductos.Servicios;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ICategoriaRepository, MemoriaCategoria>();
builder.Services.AddSingleton<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddSingleton<ICarroRepository, MemoriaCarro>();
builder.Services.AddSingleton<ICarroServicio, CarroServicio>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var categoriaService = scope.ServiceProvider.GetRequiredService<ICategoriaServicio>();
    var path = Path.Combine(AppContext.BaseDirectory, "Data", "Datos.json");

    if (File.Exists(path))
    {
        categoriaService.CargarDatosDesdeArchivo(path);
        Console.WriteLine($"Datos cargados correctamente en memoria");
    }
    else
    {
        Console.WriteLine($"Archivo no encontrado: {path}. Por favor cree el archivo Datos.json en la carpeta Data.");
    }
}

//app.UseSwagger();
//app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
