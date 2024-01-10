
using HospitalManagementSystemMvc.Data;
using HospitalManagementSystemMvc.Service.Doctor;
using HospitalManagementSystemMvc.Services.Appointment;
using HospitalManagementSystemMvc.Services.Doctor;
using HospitalManagementSystemMvc.Services.Patient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HospitalManagementSystemDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("HospitalManagmentSystemDb")
    )
);

builder.Services.AddScoped<IPatientService, PateintService>();
// builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();





// builder.Services.AddDefaultIdentity<PateintEntity>()
// .AddEntityFrameworkStores<HospitalManagementSystemDbContext();

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
