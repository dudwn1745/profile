namespace Auth.Commands
{
    public class JoinUserCommand : IRequest<JoinUserViewModel>
    {
        /// <summary>
        /// 유저아이디를 가져옵니다.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 닉네임 입력값을 가져옵니다.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 비밀번호 확인
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 이메일 주소를 가져옵니다.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 클라이언트 IP를 가져오거나 설정합니다.
        /// </summary>
        public string ClientIp { get; set; }
    }

    public class JoinUserCommandHandler : IRequestHandler<JoinUserCommand, JoinUserViewModel>
    {
        public async Task<List<JoinUserViewModel>> Handle(JoinUserCommand request, CancellationToken cancellationToken)
        {
            //유효성 및 비즈니스 로직 체크 후 회원가입

            return new JoinUserViewModel()
            {
                BirthDay = config.BirthDay,
                UserId = config.UserId,
                ClientIp = config.ClientIp,
                Email = config.Email,
                Nickname = config.Nickname
            };
        }
    }
}