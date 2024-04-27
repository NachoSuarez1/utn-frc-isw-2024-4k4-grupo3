using back.Repositories.Abstractions;
using back.Repositories.Implementations;
using back.Services.Notifications;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSingleton<IOrderRepository, EFOrderRepository>();
builder.Services.AddSingleton<IQuoteRepository, EFQuoteRepository>();
builder.Services.AddSingleton<IUserRepository, EFUserRepository>();

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
