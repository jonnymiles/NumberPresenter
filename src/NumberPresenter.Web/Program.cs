using NumberPresenter.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<INumberService, NumberService>();
builder.Services.AddScoped<IRomanService, RomanService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");
});

app.Run();
