using gestion_de_tareas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext con la cadena de conexión a MySQL
builder.Services.AddDbContext<AgendaDBContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Registrar el servicio Tareaservice
builder.Services.AddScoped<Tareaservice>();

// Registrar el servicio Usuarioservice
builder.Services.AddScoped<UsuarioService>();

// Agregar Razor Pages
builder.Services.AddRazorPages();

// 🔹 Agregar soporte para sesiones
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad antes de que expire la sesión
    options.Cookie.HttpOnly = true; // Solo accesible desde HTTP
    options.Cookie.IsEssential = true; // Esencial para el funcionamiento del sistema
});

// 🔹 Agregar servicio para acceder a la sesión
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔹 Habilitar sesiones en la aplicación
app.UseSession();

app.UseAuthorization();

// Redirigir automáticamente al Login cuando la aplicación inicie
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/Login");
        return;
    }
    await next();
});

// Mapear Razor Pages
app.MapRazorPages();

app.Run();


