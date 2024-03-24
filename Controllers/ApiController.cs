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
}
