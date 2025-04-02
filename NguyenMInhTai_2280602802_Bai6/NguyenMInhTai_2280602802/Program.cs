
using Microsoft.EntityFrameworkCore;
using NguyenMinhTai_2280602802.Model;
using NguyenMinhTai_2280602802.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ensure the connection string is correctly configured in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Configure OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowOrigins", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Logging
app.Logger.LogInformation("🚀 Application is starting...");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MyAllowOrigins");

app.UseAuthentication(); // Nếu có xác thực
app.UseAuthorization();

app.MapControllers();

app.Run();

