using GestiondesSalles.Data;
using GestiondesSalles.ExceptionHandlerMidls;
using GestiondesSalles.IRepository;
using GestiondesSalles.Repository;
using GestiondesSalles.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoomRepository,RoomRepository>();
builder.Services.AddScoped<IEquipementRepository,EquipementRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddSingleton<ExceptionMidl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthorization();

app.UseMiddleware<ExceptionMidl>();

app.MapControllers();

app.Run();
