using backendnet.Domain.IRepositories;
using backendnet.Domain.IServices;
using backendnet.Persistence.Context;
using backendnet.Persistence.Repositories;
using backendnet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var builder2 = new ConfigurationBuilder();

builder2.AddJsonFile("appsettings.json");
builder2.AddEnvironmentVariables();

var configuration = builder2.Build();



// Add services to the container. agregar servicios

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

//Servicios

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<ICuestionarioService, CuestionarioService>();


//Repositories

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILoginRepository,LoginRepository>();
builder.Services.AddScoped<ICuestionarioRepository, CuestionarioRepository>();

//cors

builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Add Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = configuration["Jwt:Issuer"],
    ValidAudience = configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
    ClockSkew = TimeSpan.Zero
});
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Context
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
