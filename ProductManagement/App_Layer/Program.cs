using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CatagoryRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<CatagoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<DataAccessFactory>();

builder.Services.AddScoped(typeof(Repository<>));

builder.Services.AddDbContext<PMSSDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});


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
