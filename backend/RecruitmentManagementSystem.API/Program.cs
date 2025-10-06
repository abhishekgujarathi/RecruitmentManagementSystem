using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RecruitmentManagementSystem.API.Data;
using RecruitmentManagementSystem.API.Services;
using Scalar.AspNetCore;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register automapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});

// Register AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDatabase"))
);

// adding authentication config for using jwt as bearer token in authorization
// Authorization: Bearer <token> validation doing config here
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!))
        };
    });

// Register data access and business logic
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRecruitersService, RecruitersService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
