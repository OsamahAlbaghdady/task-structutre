using System.Globalization;
using BackEndStructuer.Extensions;
using BackEndStructuer.Extensions;
using BackEndStructuer.Helpers;
using BackEndStructuer.Repository;
using BackEndStructuer.Schedule;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using ConfigurationProvider = BackEndStructuer.Helpers.ConfigurationProvider;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
.MinimumLevel.Error()
.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("status")); 
});

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal });
});;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<PascalCaseQueryParameterFilter>();
});
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
IConfiguration configuration = builder.Configuration;
ConfigurationProvider.Configuration = configuration;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseMiddleware<CustomUnauthorizedMiddleware>();
app.UseMiddleware<CustomPayloadTooLargeMiddleware>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var repositoryWrapper = serviceProvider.GetRequiredService<IRepositoryWrapper>();

    var notifyEndReserved = new NotifyEndReserved( TimeSpan.FromMilliseconds(1000) ,repositoryWrapper);
    notifyEndReserved.Start();
}

app.Run();