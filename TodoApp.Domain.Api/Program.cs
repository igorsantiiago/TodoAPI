
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Infra.Data;
using TodoApp.Domain.Infra.Repositories;
using TodoApp.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();

    //builder.Services.AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("Database"));
    var connection = builder.Configuration.GetConnectionString("connectionString");
    builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(connection));

    builder.Services.AddTransient<ITodoRepository, TodoRepository>();
    builder.Services.AddTransient<TodoHandler, TodoHandler>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    //{
    //    options.Authority = "https://securetoken.google.com/project00...00";
    //    options.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuer = true,
    //        ValidIssuer = "https://securetoken.google.com/project00...00",
    //        ValidateAudience = true,
    //        ValidAudience = "project00...00",
    //        ValidateLifetime = true
    //    };
    //});
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}