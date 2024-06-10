using CRUDTest.DataAccess.DBC;
using CRUDTest.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
               .AllowAnyHeader() 
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("crudtest"));
});

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllers();

app.Run();
