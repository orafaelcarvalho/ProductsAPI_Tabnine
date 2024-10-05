using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsAPI_Tabnine.Application.Interfaces;
using ProductsAPI_Tabnine.Application.Services;
using ProductsAPI_Tabnine.Domain.Interfaces;
using ProductsAPI_Tabnine.Infra.DataContext;
using ProductsAPI_Tabnine.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<ProductsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();