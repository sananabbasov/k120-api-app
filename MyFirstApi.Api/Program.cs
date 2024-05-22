using System.Globalization;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MyFirstApi.Api.Filters;
using MyFirstApi.Api.Models;
using MyFirstApi.Business.DependecyResolver;
using MyFirstApi.Business.Validator;
using NpgsqlTypes;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
    .AddFluentValidation(configuration =>
    {
        configuration.RegisterValidatorsFromAssemblyContaining<CategoryValidator>();
        configuration.DisableDataAnnotationsValidation = true;
        configuration.ValidatorOptions.LanguageManager.Culture = new CultureInfo("az-AZ");
    })
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);;

Logger log = new LoggerConfiguration()
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("Default"), "logs", needAutoCreateTable: true,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
        {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
        {"level", new LevelColumnWriter(true , NpgsqlDbType.Varchar)},
        {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
        {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
        {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
    })
    .Enrich.FromLogContext()
    .MinimumLevel.Error()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddServiceRegistiration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.MapControllers();
app.Run();

