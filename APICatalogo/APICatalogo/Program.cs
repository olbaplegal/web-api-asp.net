using APICatalogo.Context;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Extensions;
using APICatalogo.Filter;
using APICatalogo.Logging;
using APICatalogo.Repositories;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson(); // aplicando o NewtonsoftJson

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(); // incluindo serviço de autorização
builder.Services.AddAuthentication("Bearer").AddJwtBearer(); // incluindo serviço da autenticação

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseMySql(mySqlConnection,
                 ServerVersion.AutoDetect(mySqlConnection)));


builder.Services.AddTransient<IMeuServico, MeuServico>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});

builder.Services.AddScoped<ApiLoggingFilter>();


builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

builder.Services.AddAutoMapper(typeof(ProdutoDTOMappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();