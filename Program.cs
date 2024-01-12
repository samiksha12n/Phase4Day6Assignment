using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phase4Day6Assignment.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Phase4Day6AssignmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Phase4Day6AssignmentDbContext") ?? throw new InvalidOperationException("Connection string 'Phase4Day6AssignmentDbContext' not found.")));

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
