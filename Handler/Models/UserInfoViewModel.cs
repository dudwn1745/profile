public class UserInfoViewModel
{
	/// <summary>
	/// 유저의 이름을 가져오거나 설정합니다.
	/// </summary>
	public string UserName { get; set; }

	/// <summary>
	/// 유저의 아이디를 가져오거나 설정합니다.
	/// </summary>
	public string UserId { get; set; }

	/// <summary>
	/// 관리자 계정 여부를 가져오거나 설정합니다.
	/// </summary>
	public bool IsAdmin { get; set; }
}