using CFWebApiDB.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// ✅ Swagger services (IMPORTANT)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NmsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbConn")
    )
);

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ✅ This opens browser UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
