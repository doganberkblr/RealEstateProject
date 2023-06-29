var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); 

app.UseStatusCodePagesWithReExecute("/Hata/HataSayfasi", "?code={0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=LoginIndex}/{id?}");

app.Run();
