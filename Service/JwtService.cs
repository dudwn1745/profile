using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using auth.Models;

/// <summary>
/// JWT 토큰 생성 관련 비즈니스 로직을 정의합니다.
/// </summary>
public class JwtService
{
    private readonly AppConfig _config;
    private readonly ILogger<JwtService> _logger;
    private readonly JwtSecurityTokenHandler Token = new JwtSecurityTokenHandler();

    /// <summary>
    /// 생성자
    /// </summary>
    public JwtService(AppConfig config, ILogger<JwtService> logger)
    {
        _config = config;
        _logger = logger;
    }

    /// <summary>
    /// 액세스 토큰 생성
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    private string CreateAccessToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SigningKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_config.Token.AccessExpired),
            signingCredentials: credentials
        );

        return token.WriteToken(tokeOptions);
    }

    public TokenModel GenerateToken(IEnumerable<Claim> claims, bool isRemember)
    {
        var token = new TokenModel();
        try
        {
            token.AccessToken = CreateAccessToken(claims);
            token.RefreshToken = isRemember ? CreateRefreshToken() : "";
        }
        catch (Exception ex)
        {
            //실패 로그
            _logger.LogError(ex, "[Auth] AccessToken Failed {claims}, {message}", claims, ex.Message);
        }

        return token;
    }

    /// <summary>
    /// 리프래시 토큰 생성
    /// </summary>
    /// <returns></returns>
    private string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    /// <summary>
    /// 리프레시 토큰 생성
    /// </summary>
    /// <param name="accessToken"></param>
    /// <returns></returns>
    public TokenModel RefreshToken(string accessToken)
    {
        var refresh = new TokenModel();
        try
        {
            // 만료된 클레림 정보들을 가져온다.
            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal != null && principal?.Identity != null)
            {
                refresh.AccessToken = CreateAccessToken(principal.Claims);
                refresh.RefreshToken = CreateRefreshToken();
            }
        }
        catch (Exception ex)
        {
            //실패 로그
            _logger.LogError(ex, "[Auth] RefreshToken Failed {accessToken}, {message}", accessToken, ex.Message);
        }

        return refresh;
    }

    /// <summary>
    /// 만료된 토큰에 저장되어있는 클레임 정보들을 가져온다.
    /// </summary>
    /// <param name="accessToken"></param>
    /// <returns></returns>
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _config.Issuer,
            ValidAudience = _config.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SigningKey"])),
            ValidateLifetime = false // 토큰 수명의 만료일자 체크하지 않음 
        };

        var principal = token.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        // 토큰 관련 유효성 체크
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }

        return principal;
    }
}
