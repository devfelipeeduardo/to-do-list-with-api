using ToDoListAPI.Data;
using ToDoListAPI.Services;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Interfaces.Services;
using ToDoListAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddScoped<IListsManager, ListsManager>();
builder.Services.AddScoped<IListsManagerService, ListsManagerService>();

//Banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Controllers
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//Pipelines
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
