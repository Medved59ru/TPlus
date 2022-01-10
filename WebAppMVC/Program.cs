using WebAppMVC.Models;
using WebAppMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<FileParserService>();
builder.Services.AddScoped<CalendarService>();
builder.Services.AddScoped<ConsumptionService>();
builder.Services.AddScoped<ConsumerService>();
builder.Services.AddScoped<PriceService>();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddScoped<DbCombine>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
