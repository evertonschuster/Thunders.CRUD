using System.Reflection;
using Thunders.CRUD.Api.Extensions;
using Thunders.CRUD.Application.Extensions;
using Thunders.CRUD.infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\PublicApi.xml");
    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\PublicApplication.xml");
});
builder.Services.AddApplicationMediator<Program>();
builder.Services.AddApplicationInjection();
builder.Services.AddInfraInjection();
builder.Services.AddLocalApplicationContext();

var app = builder.Build();
app.MigrateApplicationDataBase();



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
