using CovidDataPortalApi.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using CovidDataPortalApi.Models.Domain;
using CovidDataPortalApi.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});
builder.Services.AddControllers();


builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT Bearer Token",
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
    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] { } }
    });
});



builder.Services.AddDbContext<CovidDataPortalApi.Data.CovidDataPortalDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConString"));
});
builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>()
    .AddEntityFrameworkStores<CovidDataPortalDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IDeathRepository, DeathReposotory>();
builder.Services.AddScoped<ICaseClassRepository, CaseClassRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience=builder.Configuration["Jwt:Audience"],
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("angularApplication");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
