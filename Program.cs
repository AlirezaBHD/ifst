using FluentValidation;
using FluentValidation.AspNetCore;
using ifst.API.ifst.API.Controllers;
using ifst.API.ifst.API.Middleware;
using ifst.API.ifst.Application.FluentValidation;
using ifst.API.ifst.Application.FluentValidation.AlbumValidator;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Application.Interfaces.ServiceInterfaces;
using ifst.API.ifst.Application.Services;
using ifst.API.ifst.Domain.Entities;
using ifst.API.ifst.Infrastructure.Data;
using ifst.API.ifst.Infrastructure.Data.Repository;
using ifst.API.ifst.Infrastructure.FileManagement;
using JsonPatchSample;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<FileService>();


builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IPioneersRepository, PioneersRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IInstituteRepository, InstituteRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IPublicImageRepository, PublicImageRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IAparatVideoRepository, AparatVideoRepository>();
builder.Services.AddScoped<IAboutUsRepository, AboutUsRepository>();
//
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//
builder.Services.AddScoped(typeof(IGeneralServices<>), typeof(GeneralServices<>));
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IPioneersService, PioneersService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IContactInformationService, ContactInformationService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<INewsletterService, NewsletterService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IInstituteService, InstituteService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IPublicImageService, PublicImageService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IAparatVideoService, AparatVideoService>();
builder.Services.AddScoped<IAboutUsService, AboutUsService>();
builder.Services.AddScoped(typeof(IPatchService<,>), typeof(PatchService<,>));
builder.Services.AddValidatorsFromAssemblyContaining<CreateAlbumValidator>();
builder.Services.AddFluentValidationAutoValidation();


//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//newton
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new DefaultContractResolver());


//Not Null Filter
// builder.Services.AddControllers(options =>
// {
//     options.Filters.Add<ValidateNotNullFilter>();
// });

var app = builder.Build();


//Middleware
app.UseMiddleware<ValidationMiddleware>();
app.UseMiddleware<ValidationExceptionMiddleware>();


//For Swagger Dark Theme
app.UseStaticFiles();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
});

app.MapControllers();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}