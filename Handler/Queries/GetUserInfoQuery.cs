
namespace Auth.Queries
{
    [Authorize]
    public class GetUserInfoQuery : IRequest<UserInfoViewModel>
    {
        // 요청 파라미터를 정의합니다.
        // Sample
        // public string UserId { get; set; }
    }

    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserInfoViewModel>
    {
        private readonly IDbContext _context;
        private readonly IDateTime _date;

        public GetUserInfoQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserInfoViewModel>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            return await (
                   from ui in _context.UserInfo
                   join ua in _context.UserAuth on ui.Id equals ua.Id
                   where ui.Enabled
                   orderby pe.Id descending
                   select new UserInfoViewModel
                   {
                       UserName = ui.UserName,
                       UserId = ui.UserId,
                       IsAdmin = ua.IsAdmin
                   }).FirstOrDefaultAsync();
        }
    }
}