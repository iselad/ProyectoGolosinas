
using CurrieTechnologies.Razor.SweetAlert2;
using ProyectoGolosinas.Data;
using ProyectoGolosinas.Interfaces;
using ProyectoGolosinas.Servicios;
//Configuraciones del servidor 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//Declarar una variable 
//Accedemos al archivo appsettings.json
MySQLconfiguracion conexionC = new MySQLconfiguracion(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(conexionC); 
builder.Services.AddScoped<IUsuarioS,SUsuarios>();
builder.Services.AddSweetAlert2();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
