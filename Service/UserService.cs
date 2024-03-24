using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using auth.Models;

/// <summary>
/// LoginUser
/// </summary>
public class LoginUser : IKsopUser
{
    private readonly IHttpContextAccessor _context;

    /// <summary>
    /// 생성자
    /// </summary>
    public LoginUser(IHttpContextAccessor context)
    {
        _context = context;
    }

    /// <summary>
    /// IsAuthenticated
    /// </summary>
    public bool IsAuthenticated
    {
        get
        {
            return _context.HttpContext?.User.Identity?.IsAuthenticated ?? false;
        }
    }

    /// <summary>
    /// Nickname
    /// </summary>
    public string Nickname
    {
        get
        {
            return Decrypt(_context.HttpContext?.User?.FindFirst("Nickname")?.Value);
        }
    }

    /// <summary>
    /// UserId
    /// </summary>
    public string UserId
    {
        get
        {
            return Decrypt(_context.HttpContext?.User?.FindFirst("UserId")?.Value);
        }
    }
}