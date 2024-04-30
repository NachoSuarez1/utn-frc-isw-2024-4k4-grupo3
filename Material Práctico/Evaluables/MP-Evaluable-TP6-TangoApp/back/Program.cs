using back.Data;
using back.Data.Repositories.Abstractions;
using back.Data.Repositories.Implementations;
using back.Services.EntityServices;
using back.Services.Notifications;
using back.Services.Payments;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<IPaymentOptionRepository, EFPaymentOptionRepository>();
builder.Services.AddScoped<IStateRepository, EFStateRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
builder.Services.AddScoped<IQuoteRepository, EFQuoteRepository>();

builder.Services.AddTransient<QuoteServices>();
builder.Services.AddTransient<OrderServices>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IPaymentServices, DefaultPaymentServices>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
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

app.UseCors("AllowLocalhost3000");

app.MapControllers();

app.Run();
