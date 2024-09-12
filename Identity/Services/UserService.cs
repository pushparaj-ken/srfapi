using Application.Contracts.Identity;
using Application.Models.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(q => new User
        {
            Email = q.Email,
            FirstName = q.FirstName,
            LastName = q.LastName,
            Id = q.Id
        }).ToList();
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id
        };
    }

}
