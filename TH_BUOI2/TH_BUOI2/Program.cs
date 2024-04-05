using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<IDonHangRepository, EFDonHangRepository>();
builder.Services.AddScoped<IDonHangChiTietRepository, EFDonHangChiTietRepository>();
builder.Services.AddScoped<IImageRepository, EFImageRepository>();
builder.Services.AddScoped<IThuongHieuRepository, EFThuongHieuRepository>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

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
