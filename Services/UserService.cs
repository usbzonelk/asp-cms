using Microsoft.AspNetCore.Identity;
using aspCMS.Models;
using aspCMS.Data;
using aspCMS.Auth;

public class UserService
{
    private readonly UserManager<AdminUsers> _userManager;
    private readonly AppDBContext _dbContext;

    public UserService(UserManager<AdminUsers> userManager, AppDBContext dbContext)
    {
        _userManager = userManager;
        _dbContext = dbContext;
    }

    public async Task AddUserManuallyAsync(UserManager<AdminUsers> userManager, AppDBContext dbContext)
    {
        var newUser = new AdminUsers
        {
            UserName = "newuser",
            Email = "newuser@example.com",
        };

        var result = await userManager.CreateAsync(newUser, "Password123!");

        if (result.Succeeded)
        {

            await dbContext.SaveChangesAsync();
        }
        else
        {
        }
    }
}
