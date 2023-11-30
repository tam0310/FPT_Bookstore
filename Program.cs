using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FPT_BOOKSTORE.Data;
using FPT_BOOKSTORE.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FPT_BOOKSTOREDBContextConnection") ?? throw new InvalidOperationException("Connection string 'FPT_BOOKSTOREDBContextConnection' not found.");

builder.Services.AddDbContext<FPT_BOOKSTOREDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<FPT_BOOKSTOREUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<FPT_BOOKSTOREDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
});

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
app.MapRazorPages();

app.Run();
