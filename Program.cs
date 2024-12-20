var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add controller services
builder.Services.AddEndpointsApiExplorer(); // Enables Swagger
builder.Services.AddSwaggerGen(); // Adds Swagger for API documentation

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Enable Swagger UI
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthorization(); // Add authorization middleware

app.MapControllers(); // Map attribute-routed controllers

app.Run(); // Run the application
