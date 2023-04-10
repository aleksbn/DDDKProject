using DDDKHostAPI;
using DDDKHostAPI.Configurations;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Repository;
using DDDKHostAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

//1.1.2   Konfiguracija seriloga
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().WriteTo.File(
        path: "logs\\log-.txt",
        outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Information
    ));

//2.1.7 Dodajemo bazu podataka prilikom startovanja
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(ServiceExtensions.GetConnectionString()));
//4.1.4 Ukljucujemo sistem autentifikacije (sledece dvije linije)
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
//4.4.3 Pozivamo konfiguraciju za Jwt
builder.Services.ConfigureJWT(builder.Configuration);
//1.2.1 dodavanje polise za pristup end pointima
builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", b =>
    {
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
//2.4.6 Ukljucujemo AutoMapper u Startup
builder.Services.AddAutoMapper(typeof(MapperInitializer));
//3.1.2 Dodajemo UnitOfWork kako bismo ga mogli koristiti bez instanciranja (klasicni dependency injection) - AddTransient dodaje objekat na svaki zahtjev, AddSingleton je 1 na cijelu aplikaciju, a
//AddScoped je za odredjeni set zahtjeva, za svaki kontroler koji se instancira
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//4.4.7 Dodajemo AuthManager kako bismo ga mogli koristiti u aplikaciji
builder.Services.AddScoped<IAuthManager, AuthManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
// 3.1.4 Na .AddControllers() dodajemo .AddNewtonsoftJson() komandu
builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
//6.2.3 Pozivamo metodu za rjesavanje gresaka
app.ConfigureExceptionHandling();

app.UseHttpsRedirection();
//1.2.2 upotreba polise za pristup end pointima
app.UseCors("AllowAll");

//4.5.2 Aktiviramo autentifikaciju i autorizaciju
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Logger.LogInformation("App is running");

app.Run();
