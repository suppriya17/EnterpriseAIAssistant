using EnterpriseAIAssistant.API.Interfaces;
using EnterpriseAIAssistant.API.Data;
using EnterpriseAIAssistant.API.Repository;
using Microsoft.EntityFrameworkCore;
using EnterpriseAIAssistant.Interfaces;
using EnterpriseAIAssistant.Services;
using EnterpriseAIAssistant.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IChatRepository,ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IOpenAIService, OpenAIService>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
