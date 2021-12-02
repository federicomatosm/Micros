using Lil.Search.Interfaces;
using Lil.Search.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("appsettings.json", optional:false);
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICustomersService, CustomerService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ISalesService, SalesService>();


builder.Services.AddHttpClient("customerService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Customers"]);
});
builder.Services.AddHttpClient("productsServices", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Products"]);
});

builder.Services.AddHttpClient("salesService", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Services:Sales"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

