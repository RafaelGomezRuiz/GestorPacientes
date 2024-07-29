
using PatientManager.Infraestructure.Persistence;
using PatientManager.Core.Application;
using WebApp.GestorPacientes.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();


builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddInfraestrutureLayer(builder.Configuration);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
