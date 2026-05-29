using Ecommerce.API.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureProjectService();
builder.Services.ConfigureProjectDatabaseService(builder.Configuration);
builder.Services.ConfigureProjectJwtService(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
