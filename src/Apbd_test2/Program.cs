using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MyDatabase");

builder.Services.AddDbContext<RecordManiaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRecordManiaService, RecordManiaService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();