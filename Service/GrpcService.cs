using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Grpc.Core;

/// <summary>
/// Grpc 통신 관련 서비스
/// </summary>
public class GrpcService : UserService.GreeterBase
{
    readonly ISender _mediator;

	public GrpcService(ISender mediator)
	{
         _mediator = mediator;
	}

    /// <summary>
    /// 회원가입
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override Task<UserResponseModel> JoinUser(UserRequestModel request, ServerCallContext context)
    {
        PcPokerExchangeInfoModel result = await _mediator.Send(new PcPokerExchangeInfoQuery
        {
            Cn = request.Cn,
            ClientIp = request.ClientIp,
            AccessToken = request.AccessToken
        });

        return new UserRequestModel()
        {
            Code = "0",
            Message = "success",
            Data = new UserResponseModel.Types.Data()
            {
                SeqNo = userSeqno
            }
        }
    }
}
