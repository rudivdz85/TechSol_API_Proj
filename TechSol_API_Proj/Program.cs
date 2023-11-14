using TechSol_API_Proj.Interfaces;
using TechSol_API_Proj;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IServiceCollection serviceCollection = builder.Services.AddScoped<IDatabaseOperations, DatabaseOperations>(provider =>
    new DatabaseOperations(builder.Configuration.GetConnectionString("TechSolutionsDB")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}


app.UseCors("MyAllowSpecificOrigins"); // Use the CORS policy
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");



app.MapFallbackToFile("index.html");

app.Run();