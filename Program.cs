using SistemaAprendices.Interfaces;
using SistemaAprendices.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Configuración de Sesiones y Acceso al Contexto (Necesario para el Login)
builder.Services.AddHttpContextAccessor(); // Permite usar la sesión en las Vistas (_Layout)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // La sesión dura 30 minutos
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 2. Inyección de dependencias de tus servicios
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IAprendizService, AprendizService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();

var app = builder.Build();

// 3. Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Importante para CSS y JS

app.UseRouting();

// --- ¡OJO! El UseSession debe ir siempre después de UseRouting y ANTES de UseAuthorization ---
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();