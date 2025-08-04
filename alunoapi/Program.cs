using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using alunoapi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<alunoapiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("alunoapiContext") ?? throw new InvalidOperationException("Connection string 'alunoapiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
