using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserCustomFilter.API.Factory;
using UserCustomFilter.Persistence.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    //ReferenceLoop
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnectionString")));
builder.Services.AddScoped<ICustomFilterFactory, CustomFilterFactory>();
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