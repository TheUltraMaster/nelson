using MudBlazor.Services;
using BackOffice.Components;
using BackOffice.Services;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using Bycript;
using Bucket;
using Minio;
var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<DatabseContext>(opt => opt.UseMySQL("Server=localhost;Database=Nelson;Uid=root;Pwd=Judith0709;Convert Zero Datetime=True;"));

// Add custom services
builder.Services.AddScoped<IAlimentoService, AlimentoService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IBitacoraService, BitacoraService>();
builder.Services.AddScoped<IBitacoraPesoService, BitacoraPesoService>();
builder.Services.AddScoped<IBitacoraVacunaService, BitacoraVacunaService>();
builder.Services.AddScoped<ICompraAlimentoService, CompraAlimentoService>();
builder.Services.AddScoped<IEstadoAnimalService, EstadoAnimalService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IHistorialAlimenticioService, HistorialAlimenticioService>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<IRazaService, RazaService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITiposAlimentoService, TiposAlimentoService>();
builder.Services.AddScoped<IUnidadesDeMedidaAlimentoService, UnidadesDeMedidaAlimentoService>();
builder.Services.AddScoped<IVacunaService, VacunaService>();
builder.Services.AddScoped<BackOffice.Mapper.Mapa>();
builder.Services.AddScoped<IBCryptService, BCryptService>();

// Minio configuration
builder.Services.AddScoped<IMinioClient>(provider =>
{
    return new MinioClient()
        .WithEndpoint("localhost", 9000)
        .WithCredentials("minioadmin", "minioadmin")
        .Build();
});

builder.Services.AddScoped<IMinioService>(provider =>
{
    var minioClient = provider.GetRequiredService<IMinioClient>();
    return new MinioService(minioClient, "localhost", 9000, false);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
