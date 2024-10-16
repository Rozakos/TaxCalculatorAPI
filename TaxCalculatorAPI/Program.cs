var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<TaxCalculatorAPI.Services.TaxCalculatorService>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();  // Required for Swagger to work
builder.Services.AddSwaggerGen();  // Adds Swagger generator services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxCalculatorAPI v1");
    });
}

// Enable serving static files from wwwroot
app.UseStaticFiles();  // <-- This line allows serving static files like HTML, CSS, JS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
