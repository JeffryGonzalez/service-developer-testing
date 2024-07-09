using Catalog.Api.Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapCatalog();
}
app.UseSwagger();
app.UseSwaggerUI();
// Todo: Talk about Feature Flags Tomorrow.
app.Run();

public partial class Program { }
