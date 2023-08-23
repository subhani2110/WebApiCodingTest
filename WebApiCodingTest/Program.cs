using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiCodingTest.Data;
using WebApiCodingTest.Data.BL;
using WebApiCodingTest.Data.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Default"))
       );
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAddOperationsBL, AddOperationsBL>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

var addOperationsBL = builder.Services.BuildServiceProvider().GetService<IAddOperationsBL>();

app.MapPost("/add", (int num1, int num2) =>
{
    var sum = new Operations().Add(num1, num2);
    addOperationsBL.AddAsync(new AddOperations { Num1 = num1, Num2 = num2, Sum = sum });
    return sum;
})
.WithName("add");

app.Run();

public class Operations
{

    public int Add(int num1, int num2)
    {
        
        return num1 + num2;
    }
}