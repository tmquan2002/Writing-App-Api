using Microsoft.OpenApi.Models;
using WritingApp.Application.Extentions;
using WritingApp.Domain.Entities;
using WritingApp.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token here, Ex: Bearer <your-token>"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            []
        }
    });
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();
var scope = app.Services.CreateScope();
//var seeder = scope.ServiceProvider.GetRequiredService<IWritingSeeder>();

//await seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGroup("api/auth")
    .WithTags("Auth")
    .MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAngularApp");

app.MapControllers();
app.Run();

