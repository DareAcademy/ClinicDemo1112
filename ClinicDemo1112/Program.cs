using ClinicDemo1112.data;
using ClinicDemo1112.servicies;
using Microsoft.Extensions.FileProviders;



var builder = WebApplication.CreateBuilder(args);

var UploadImagesPath = builder.Configuration.GetSection("UploadImages");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountryService, CountryServicies>();
builder.Services.AddScoped<IPatientService, PatientServicies>();
builder.Services.AddDbContext<ClinicContext>();

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

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"UploadImages")),
    RequestPath="/UploadImg"
});



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=PatientList}/{id?}");

app.Run();
