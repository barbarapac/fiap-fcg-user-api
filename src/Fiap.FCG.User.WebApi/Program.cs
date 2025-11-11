using Fiap.FCG.User.Application;
using Fiap.FCG.User.Infrastructure;
using Fiap.FCG.User.WebApi;
using Fiap.FCG.User.WebApi._Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); 
});

builder.Services.AddControllers(); 
builder.Services.AddInfrastructure(builder.Configuration); 
builder.Services.AddApplication(); 
builder.Services.AddWebApi(); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 
app.Run();