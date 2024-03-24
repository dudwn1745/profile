using Google.Authenticator;

/// <summary>
/// Google OTP 라이브 러리 참조하여 otp 비밀번호 인증 확인
/// </summary>
public class GoogleAuthHelper
{
    private readonly TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();

    /// <summary>
    /// Google OTP QRCode Image URL 생성
    /// </summary>
    /// <param name="accountTitle">OTP 계정 타이틀</param>
    /// <param name="secretKey">관리자 아이디로 저장(암호화)</param>
    /// <returns></returns>
    public string GenerateQrCodeUrl(string accountTitle, string secretKey)
    {
        SetupCode setupInfo = tfa.GenerateSetupCode(null, accountTitle, secretKey, false, 3);
        return setupInfo.QrCodeSetupImageUrl;
    }

    /// <summary>
    /// Google OTP 유효성 체크
    /// </summary>
    /// <param name="secretKey">암호화 된 관리자아이디(키값)</param>
    /// <param name="twoFactorCode">OTP 코드값</param>
    /// <returns></returns>
    public bool ValidateTwoFactorPin(string secretKey, string twoFactorCode)
    {
        return tfa.ValidateTwoFactorPIN(secretKey, twoFactorCode, TimeSpan.FromSeconds(30));
    }
}