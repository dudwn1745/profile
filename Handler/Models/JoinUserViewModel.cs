public class JoinUserViewModel
{
	/// <summary>
	/// 생년월일 정보를 가져오거나 설정합니다.
	/// </summary>
	public string BirthDay { get; set; }

	/// <summary>
	/// 유저의 아이디를 가져오거나 설정합니다.
	/// </summary>
	public string UserId { get; set; }

	/// <summary>
	/// 클라이언트 IP를 가져오거나 설정합니다.
	/// </summary>
	public string ClientIp { get; set; }

	/// <summary>
	/// 이메일 주소를 가져오거나 설정합니다.
	/// </summary>
	public string Email { get; set; }

	/// <summary>
	/// 닉네임을 가져오거나 설정합니다.
	/// </summary>
	public string Nickname { get; set; }
}