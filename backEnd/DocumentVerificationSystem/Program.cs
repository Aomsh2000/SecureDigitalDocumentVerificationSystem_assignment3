using DocumentVerificationSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()  // Enable to log query details (optional, be cautious on production)
           .LogTo(Console.WriteLine, LogLevel.Information)); // Configure DbContext with the connection string

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Frontend URL (adjust as necessary)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllersWithViews(); // Add MVC services
builder.Services.AddLogging();
var app = builder.Build(); // Build the app

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Enables HTTP Strict Transport Security (HSTS) in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files (like CSS, JS, images)

app.UseCors("AllowSpecificOrigin"); // Enable CORS with the defined policy

app.UseRouting(); // Enable routing
//app.UseAuthorization(); // Enable authorization (if needed)

// Define default route pattern
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route is to the Home controller, Index action
app.MapControllers(); 
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Method: {context.Request.Method}, Path: {context.Request.Path}");
    await next.Invoke();
});
app.Run(); // Run the app
