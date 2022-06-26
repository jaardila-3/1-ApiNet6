using CustomersApi.CasosDeUso;
using CustomersApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerDataBaseContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
    //NuGet DAL MySQL: MySql.EntityFrameworkCore
    //NuGet DAL Oracle: Oracle.EntityFrameworkCore
    //NuGet DAL SqlServer: Microsoft.EntityFrameworkCore.SqlServer
});

//configuración del CORS
//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();

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

//app cors
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
