using Microsoft.AspNetCore.Identity;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models.Enum;
using StudentManagementSystem.Models.UserModel;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Interface
{
    public class DbInitializer : IDBInitializer
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly StudentDbContext _db;
        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, StudentDbContext studentDbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _db = studentDbContext;

        }

        public async Task Initializer()
        {
            if (!roleManager.RoleExistsAsync(Roles.Admin.ToString()).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString())).GetAwaiter().GetResult();
                roleManager.CreateAsync(new IdentityRole(Roles.User.ToString())).GetAwaiter().GetResult();
            }
            var user = new User
            {
                PhoneNumber = "9847035197",
                PhoneNumberConfirmed = true,
                Email = "om@gmail.com",
                UserName = "Admin",
                NormalizedEmail = "OM@GMAIL.COM",
                NormalizedUserName = "OM@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("O"),
            };
            var temp = await userManager.FindByEmailAsync(user.Email);
            if (temp is null)
            {
                var UserManager = await userManager.CreateAsync(user, "Admin@123");
                var result = _db.Users.FirstOrDefault(a => a.Email == "om@gmail.com");
                userManager.AddToRoleAsync(user, Roles.Admin.ToString()).GetAwaiter().GetResult();
                await _db.SaveChangesAsync();
            }

        }
    }
}
