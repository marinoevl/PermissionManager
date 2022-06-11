using FluentValidation.AspNetCore;
using PermissionManager.Application;
using PermissionManager.Infrastructure;
using PermissionManager.WebAPI.Common;
using PermissionManager.WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();

builder.Services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>()).AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy( 
        policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins(appSetting.ClientURL));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSeedData();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();