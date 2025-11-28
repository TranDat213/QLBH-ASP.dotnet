var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// ??ng ký d?ch v? l?u cache trong b? nh? (Session s? s? d?ng nó)
builder.Services.AddDistributedMemoryCache();
//??ng ký d?ch v? Session
builder.Services.AddSession(cfg =>
{
    // ??t tên Session - tên này s? d?ng ? Browser (Cookie)
    cfg.Cookie.Name = "QLBH";
    // Th?i gian t?n t?i c?a Session
    cfg.IdleTimeout = new TimeSpan(0, 60, 0);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Khach}/{action=Index}/{id?}");
app.UseSession();

app.Run();
