using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/**/
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<GestionDePersonas.DA.DBContexto>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<GestionVehiculos.DA.DBContexto>(options => options.UseInMemoryDatabase("VehiculosDB"));
builder.Services.AddScoped<GestionVehiculos.BL.IVehiculoRepository, GestionVehiculos.DA.VehiculoRepository>();
builder.Services.AddScoped<GestionVehiculos.BL.IAdministradorVehiculos, GestionVehiculos.BL.AdministradorVehiculos>();
/**/

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
