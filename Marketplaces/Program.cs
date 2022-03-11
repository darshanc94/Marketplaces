using Marketplaces;
using DataAccessLibrary;
using Marketplaces.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IApplicantData, ApplicantData>();
builder.Services.AddTransient<ICreditCardData, CreditCardData>();
builder.Services.AddTransient<ICreditCardLogic, CreditCardLogic>();
builder.Services.AddTransient<ILogData, LogData>();


builder.Services.AddScoped<LogRequests>();
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
