using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using auth.Models;
using MediatR;

namespace auth.Controllers;

/// <summary>
/// API 관련 컨트롤러
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private ISender _mediator;
	protected ISender Mediator => _mediator ?? (_mediator = ServiceProviderServiceExtensions.GetRequiredService<ISender>(base.HttpContext.RequestServices));
    readonly WebHelper _webHelper;

    pulic ApiController(WebHelper webHelper)
    {
        _webHelper = webHelper;
    }

    /// <summary>
    /// 액세스 토큰 생성
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost("authorize")]
    public async Task<IActionResult> Authorize(AuthRequestModel requestModel)
    {
        var result = await Mediator.Send(new AuthorizeCommand()
        {
            UserId = requestModel.UserId,
            Password = requestModel.Password
        });

        return Ok(new { result.AccessToken });
    }

    /// <summary>
    /// 유저 정보를 조회
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUserInfo()
    {
        return Ok(await Mediator.Send(new GetUserInfoQuery()));
    }

    /// <summary>
    /// 신규 유저 회원 가입
    /// </summary>
    /// <returns></returns>
    [HttpPost("join")]
    public async Task<IActionResult> SetAccountJoin()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new GrpcService.GreeterClient(channel);

        var result = client.JoinUserAsync(new UserRequest
        {
            UserId = "userID",
            Nickname = "nickName",
            Password = "test1234",
            ConfirmPassword = "test1234",
            Email = "test@naver.com",
            ClientIp = _webHelper.GetUserIp()
        });

        //결과값 닉네임만 반환
        return Ok(new { Nickname = result.Nickname });
    }
}
