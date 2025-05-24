using System;

namespace Application.Constants;

public class MailTemplates
{

public static class PasswordReset
{
    public const string SUBJECT = "Şifre Sıfırlama";
    public static string GetBody(string code, string name)
        => $@"
            <div style='font-family: Arial, sans-serif; font-size: 16px; color: #222; max-width: 600px; margin: 0 auto; background-color: #f7f7f7; padding: 20px; border-radius: 8px;'>
                <div style='background-color: white; padding: 30px; border-radius: 6px; box-shadow: 0px 2px 10px rgba(0,0,0,0.08);'>
                    <div style='text-align: center; border-bottom: 1px solid #eee; padding-bottom: 20px; margin-bottom: 20px;'>
                        <h2 style='color: #2a7ae2; margin-bottom: 10px; font-weight: 600;'>Şifre Sıfırlama</h2>
                    </div>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Sayın {name},</p>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Şifre sıfırlama talebiniz alınmıştır. Yeni şifreniz aşağıdaki gibidir:</p>
                    <div style='background-color: #f0f4ff; padding: 15px; border-radius: 5px; text-align: center; margin: 25px 0;'>
                        <span style='font-size: 24px; font-weight: bold; letter-spacing: 2px; color: #2a7ae2;'>{code}</span>
                    </div>
                    <p style='margin-bottom: 20px; line-height: 1.5;'>Güvenliğiniz için lütfen giriş yaptıktan sonra şifrenizi değiştiriniz.</p>
                    <div style='margin-top: 30px; padding-top: 20px; border-top: 1px solid #eee; font-size: 13px; color: #777; text-align: center;'>
                        <p>Bu e-posta otomatik olarak gönderilmiştir, lütfen yanıtlamayınız.</p>
                    </div>
                </div>
            </div>";
}


}
