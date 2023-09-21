using Microsoft.AspNetCore.Identity;
using aspCMS.Models;
using aspCMS.Data;
using aspCMS.Auth;
using System.Threading.Tasks;

namespace aspCMS.Services;
public class UserService
{
    private readonly UserManager<AdminUsers> _userManager;

    public UserService(UserManager<AdminUsers> userManager)
    {
        _userManager = userManager;
    }


    public async Task<IdentityResult> CreateUserAsync(AdminUsers user, string password)
    {


        var result = await _userManager.CreateAsync(user, password);

        return result;
    }

}
