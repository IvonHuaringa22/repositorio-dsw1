using Proyecto_DSWI_GP3.Data;
using Proyecto_DSWI_GP3.Data.Contrato;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


// HABILITAR SERVICIO DE SESIÓN
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();

// Dependencias
builder.Services.AddScoped<IUsuarios, UsuariosRepositorio>();
builder.Services.AddScoped<IEventos, EventosRepositorio>();
builder.Services.AddScoped<ICompras, ComprasRepository>();
builder.Services.AddScoped<ITickets, TicketRepository>();
builder.Services.AddScoped<ICompras, ComprasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// AGREGAR MIDDLEWARE DE SESIÓN
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
