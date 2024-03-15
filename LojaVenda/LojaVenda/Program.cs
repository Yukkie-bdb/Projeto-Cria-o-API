using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaTarefas.Data;
using SistemaTarefas.Repositorio;
using SistemaTarefas.Repositorio.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
/* Adicionar Chave Secreta */
string chaveSecreta = "4a813e5f-5f28-4ed3-beed-a78a483f0277";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Tarefas - API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Jwt Autentica��o",
        Description = "Entre com o JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new string[] {} }
    });
});

builder.Services.AddScoped<IUsuariosRepositorios, UsuarioRepositorio>();
builder.Services.AddScoped<IPedidosRepositorios, PedidoRepositorio>();
builder.Services.AddScoped<ICategoriaRepositorios, CategoriaRepositorios>();
builder.Services.AddScoped<IProdutoRepositorios, ProdutoRepositorios>();
builder.Services.AddScoped<IcategoriaProdutoRepositorios, CategoriaProdutosRepositorio>();


builder.Services.AddDbContext<lojaVendaDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

/*Adicionar as configura��es*/
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true, //Emissor do token,
        ValidateAudience = true, //Destinat�rio do Token
        ValidateLifetime = true, //Termino do Token
        ValidateIssuerSigningKey = true, //Chave de Assinatura
        ValidIssuer = "empresa",
        ValidAudience = "aplicacao",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
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
