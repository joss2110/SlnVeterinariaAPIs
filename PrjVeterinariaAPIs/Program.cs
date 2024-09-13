using FlowersshoesCoreMVC.DAO;
using PrjVeterinariaAPIs.DAO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ColoresDAO>();
builder.Services.AddScoped<TrabajadoresDAO>();
builder.Services.AddScoped<RolesDAO>();
builder.Services.AddScoped<StocksDAO>();
builder.Services.AddScoped<ProductosDAO>();
builder.Services.AddScoped<IngresosDAO>();
builder.Services.AddScoped<DetalleIngresosDAO>();
builder.Services.AddScoped<ClientesDAO>();
builder.Services.AddScoped<CatalogoDAO>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();