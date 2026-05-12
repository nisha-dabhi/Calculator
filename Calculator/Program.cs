using Business;
using Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// DI: Connect the Interface to the Class

//builder.Services.AddScoped<ICalService, CalService>();
builder.Services.AddScoped<AddService>();
builder.Services.AddScoped<SubService>();
builder.Services.AddScoped<MulService>();
builder.Services.AddScoped<DivService>();
builder.Services.AddScoped<SumService>();


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
    pattern: "{controller=Cal}/{action=Index}/{id?}");

app.Run();
