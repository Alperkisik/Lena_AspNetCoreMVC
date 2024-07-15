using Infrastructure;
using Application;
using Lena_AspNetCoreMVC.Endpoints;

var builder = WebApplication.CreateBuilder(args);

string databaseMdfFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "Infrastructure", "Database");

AppDomain.CurrentDomain.SetData("DataDirectory", databaseMdfFolderPath);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder
    .Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration.GetConnectionString("DatabaseConnection")!);

builder
    .Services
    .AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
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
app.UseAuthorization();


app.UseApplicationEndpoints();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
