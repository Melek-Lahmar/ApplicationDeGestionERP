//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Services de l'application
//builder.Services.AddControllersWithViews();
//builder.Services.AddFastReport();
//builder.Services.AddDbContext<ApplicationDbContextes>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContextes>();

//var app = builder.Build();

//// Middleware de gestion des requêtes HTTP
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//// Middleware de redirection basé sur le rôle
//app.Use(async (context, next) =>
//{
//    var userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
//    var signInManager = context.RequestServices.GetRequiredService<SignInManager<IdentityUser>>();

//    // Vérifier si l'utilisateur est connecté
//    var user = await userManager.GetUserAsync(context.User);
//    if (user != null)
//    {
//        // Récupérer les rôles de l'utilisateur
//        var roles = await userManager.GetRolesAsync(user);
//        if (roles.Contains("Admin"))
//        {
//            // Si l'utilisateur est Admin, redirigez vers Dashboard/Index
//            if (context.Request.Path == "/")
//            {
//                context.Response.Redirect("/Dashboard/Index");
//                return;
//            }
//        }
//    }

//    // Passer à la requête suivante
//    await next.Invoke();
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
//app.UseEndpoints(endpoint => endpoint.MapRazorPages());

//// Démarrer l'application
//app.Run();




//-----------------------------------------Code Corrigez ------------------------------------------------
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services de l'application
builder.Services.AddControllersWithViews();
builder.Services.AddFastReport();
builder.Services.AddDbContext<ApplicationDbContextes>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContextes>();

var app = builder.Build();

// Middleware de gestion des requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Middleware de redirection basé sur le rôle et la connexion de l'utilisateur
app.Use(async (context, next) =>
{
    var userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
    var signInManager = context.RequestServices.GetRequiredService<SignInManager<IdentityUser>>();

    var user = await userManager.GetUserAsync(context.User);

    if (user != null)
    {
        var roles = await userManager.GetRolesAsync(user);

        if (roles.Contains("Admin") && context.Request.Path == "/")
        {
            context.Response.Redirect("/Dashboard/Index");
            return;
        }
        else if (!roles.Contains("Admin") && context.Request.Path == "/")
        {
            context.Response.Redirect("/Home/Index");
            return;
        }
    }
    else if (!context.User.Identity.IsAuthenticated && context.Request.Path == "/")
    {
        context.Response.Redirect("/Identity/Account/Login");
        return;
    }

    await next.Invoke();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseEndpoints(endpoint => endpoint.MapRazorPages());

// Démarrer l'application
app.Run();
