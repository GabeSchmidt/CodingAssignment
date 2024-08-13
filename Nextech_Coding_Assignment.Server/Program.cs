using AutoMapper;
using Nextech_Coding_Assignment.Server.Models;
using Nextech_Coding_Assignment.Server.Services.RapidAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IAlphaVantageService, AlphaVantageService>(client =>
{
    client.BaseAddress = new Uri("https://alpha-vantage.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("x-rapidapi-key", "ffda5d3ac7msh33bd4a4c7d83c33p1638e5jsn0641ecc0aab1");
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "alpha-vantage.p.rapidapi.com");
});

var mapperConfig = new MapperConfiguration(x =>
{
    x.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("/index.html");

app.Run();
