using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
	public class EmailSendServiceClass
	{
		private readonly string _strLogin;
		private readonly string _strPassword;
		private readonly string _strSmtp;
		private readonly int _iSmtpPort;
		private string _strBody;
		private string _strSubject;

		public EmailSendServiceClass(string sLogin, string sPassword, string strServer, int iPort, string sBody)
		{
			_strLogin = sLogin;
			_strPassword = sPassword;
			_strSmtp = strServer;
			_iSmtpPort = iPort;
			_strBody = sBody;
		}

		public void SendMail(string mail)
		{
			using (MailMessage mm = new MailMessage(_strLogin, mail))
			{
				mm.Subject = _strSubject;
				mm.Body = "Hello world!";
				mm.IsBodyHtml = false;
				SmtpClient sc = new SmtpClient(_strSmtp, _iSmtpPort)
				{
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential(_strLogin, _strPassword)
				};
				try
				{
					sc.Send(mm);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
				}
			}
		}
	}
 
}
