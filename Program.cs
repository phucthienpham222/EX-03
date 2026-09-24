var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// =============================
// /Admin -> Dashboard
// =============================
app.MapControllerRoute(
    name: "admin-home",
    pattern: "Admin",
    defaults: new
    {
        area = "Admin",
        controller = "Dashboard",
        action = "Index"
    })
    .WithStaticAssets();

// =============================
// ADMIN AREA
// =============================
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

// =============================
// CLIENT
// =============================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();