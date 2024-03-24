using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using auth.Models;

/// <summary>
/// ASP.NET Core 클레임 기반 로그인 구현
/// </summary>
public class AuthService
{
    private readonly IHttpContextAccessor _context;

    public AuthService(IHttpContextAccessor context)
    {
        _context = context;
    }

    /// <summary>
    /// 로그인 설정
    /// </summary>
    /// <param name="values">claim 데이터</param>
    /// <returns></returns>
    public async Task SetLogIn(IDictionary<string, string> values)
    {
        if (values.Count == 0)
            return;

        List<Claim> claims = new List<Claim>();
        foreach (var claim in values)
        {
            claims.Add(new Claim(claim.Key, claim.Value));
        }

        var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity));
    }

    /// <summary>
    /// 로그아웃
    /// </summary>
    /// <returns></returns>
    public async Task SetLogOut()
    {
        await _context.HttpContext.SignOutAsync();
        _context.HttpContext.Response.Redirect("/Login");
    }

    /// <summary>
    /// 세팅된 claim 인증 관련 데이터 변경
    /// </summary>
    /// <param name="values">claim 데이터</param>
    /// <returns></returns>
    public async Task SetChangeClaims(IDictionary<string, string> values)
    {
        var identity = _context.HttpContext.User.Identity as ClaimsIdentity;
        if (identity.Claims == null || identity.Claims.Count() == 0) return;

        foreach (var claim in values)
        {
            var type = identity.FindFirst(claim.Key);
            if (type != null)
            {
                if (identity.TryRemoveClaim(type))
                {
                    identity.AddClaim(new Claim(claim.Key, claim.Value));
                }
            }
        }

        await _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }
}
