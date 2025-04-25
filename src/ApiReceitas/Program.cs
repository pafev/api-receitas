using ApiReceitas.Persistence;
using Microsoft.EntityFrameworkCore;
using ApiReceitas.Services;

var builder = WebApplication.CreateBuilder(args);
{
    var dbConn = builder.Configuration.GetConnectionString("DbConnection");
    builder.Services.AddDbContext<SqLiteDbContext>(options => options.UseSqlite(dbConn));
    builder.Services.AddScoped<IRecipesService, RecipesService>();
    builder.Services.AddScoped<IIngredientsService, IngredientsService>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();