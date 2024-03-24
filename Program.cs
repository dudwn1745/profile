using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var appconfig = builder.Configuration.GetSection("AppConfig").Get<AppConfig>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// ASP.NET Core 클레임 기반 로그인 구현 -- AuthService.cs
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.Cookie.Name = "AccessToken";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.Events.OnRedirectToLogin = (context) =>
    {
        var web = context.HttpContext.RequestServices.GetRequiredService<WebHelper>();
        if (web.IsAjaxRequest())
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        else
            context.Response.Redirect("/Login");

        return Task.CompletedTask;
    };
});

// JWT Authentication 로그인 구현 -- JwtService.cs
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = appconfig.Audience, // 토큰 대상자
        ValidIssuer = appconfig.Issuer, // 토큰 발행자
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"])),
        ClockSkew = TimeSpan.Zero,
        SaveSigninToken = true
    };
});

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

// 모바일 페이지 라우트 설정
app.MapAreaControllerRoute(
    name: "Mobile",
    areaName: "Mobile",
    pattern: "m/{controller=Home}/{action=Index}");

app.Run();
