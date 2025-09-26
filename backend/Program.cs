using Microsoft.EntityFrameworkCore;
using backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Register repositories
builder.Services.AddScoped<backend.Repos.Interfaces.IUserRepository, backend.Repos.UserRepository>();
builder.Services.AddScoped<backend.Repos.Interfaces.IProductRepository, backend.Repos.ProductRepository>();
builder.Services.AddScoped<backend.Repos.Interfaces.INotificationRepository, backend.Repos.NotificationRepository>();

// Register application services
builder.Services.AddScoped<backend.Services.Interfaces.IUserService, backend.Services.UserService>();
builder.Services.AddScoped<backend.Services.Interfaces.IProductService, backend.Services.ProductService>();
builder.Services.AddScoped<backend.Services.Interfaces.INotificationService, backend.Services.NotificationService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
