using MongoDB.Driver;
using MongoMvcApp.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabaseName = builder.Configuration["MongoDbSettings:DatabaseName"];
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);


builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(mongoDatabase);
builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
