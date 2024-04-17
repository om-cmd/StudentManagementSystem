using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//yo chai mapper configure garya program.cs ma 
builder.Services.AddAutoMapper(typeof(Program));
//database connection
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//identity service
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StudentDbContext>().AddDefaultTokenProviders();
//yo chai cookie to login path ra acce deny vaue si ko path main cookie 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login"; // Specify the login page URL
    options.AccessDeniedPath = "/User/Login"; // Specify the access denied page URL
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.SlidingExpiration = true;
});
//reposiroty service add 
 
builder.Services.AddScoped<ITeacherInterface, TeacherRepository>();
builder.Services.AddScoped<IStudentInterface, StudentRepository>();
builder.Services.AddScoped<IFacultyInterface, FacultyRepository>();
builder.Services.AddScoped<ICourcesInterface, CourcesRepository>();
builder.Services.AddScoped<IChosenCourcesInterface, ChosenCourcesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
