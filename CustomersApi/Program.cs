using CustomersApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerDataBaseContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
    //NuGet MySQL: MySql.EntityFrameworkCore
    //NuGet Oracle: Oracle.ManagedDataAccess.EntityFramework
    //NuGet SqlServer: Microsoft.EntityFrameworkCore.SqlServer
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(r => r.LowercaseUrls = true);//las url en minúsculas

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
