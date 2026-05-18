using CP2_VetApi.Data;
using CP2_VetApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddHttpClient<MotorServiceClient>(client => {
    client.BaseAddress = new Uri(
        builder.Configuration["MotorService:BaseUrl"] ?? "http://localhost:8080"
    );
});

builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<TutorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.EnableAnnotations();
});

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