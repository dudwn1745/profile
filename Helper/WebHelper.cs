using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using auth.Models;

/// <summary>
/// ASP.NET Core 클레임 기반 로그인 구현
/// </summary>
public class WebHelper
{
    private readonly IHttpContextAccessor _context;

    /// <summary>
    /// 생성자
    /// </summary>
    public WebHelper(IHttpContextAccessor context)
    {
        _context = context;
    }

    public bool IsAjaxRequest()
    {
        if (_context.HttpContext?.Request.Headers != null)
        {
            return (_context.HttpContext?.Request.Headers["X-Requested-With"].ToString() ?? string.Empty) == "XMLHttpRequest";
        }

        return false;
    }

    /// <summary>
    /// IP 주소 조회
    /// </summary>
    /// <returns></returns>
    public string GetUserIp()
    {
        var ip = "127.0.0.1";
        try
        {
            //  X-Forwarded-For: client, proxy1, proxy2
            string header = _context.HttpContext?.Request.Headers["X-Forwarded-For"];

            if (string.IsNullOrEmpty(header))
            {
                return _context.HttpContext?.Connection.RemoteIpAddress?.ToString().Split(':').First() ?? ip;
            }
            else
            {
                return header.Split(',').First().Trim().Split(':').First();
            }
        }
        catch
        {
            return ip;
        }
    }
}
