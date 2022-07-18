using CRUD.Data;
using CRUD.Models;
using CRUD.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultContextConnection");
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(connectionString)); ;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DefaultContext, DefaultContext>();
/*builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
*/builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderListRepository, OrderListRepository>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
