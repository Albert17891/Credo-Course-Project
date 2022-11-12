using BankSystem.PersistenceDB.Seed;
using MyCredoBanking.Infrastracture.ServiceCollectionExtensions;
using Serilog;

var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddContext(builder.Configuration);
builder.Services.AddServicesExtension();
builder.Services.AddRepositoryServcies();

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

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await UserSeed.AddUserAndRoles(app);

app.Run();