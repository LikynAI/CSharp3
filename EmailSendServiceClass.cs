using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
	public class EmailSendServiceClass
	{
		private static string _priStrSender;
		private string _priStrServer;
		private string _priStrUser;
		private string _priStrPassword;

		public EmailSendServiceClass(string user, string password, string sender)
		{
			_priStrUser = user;
			_priStrPassword = password;
			_priStrSender = sender;
			_priStrServer = ChoseServer(_priStrSender);
		}

		private string ChoseServer(string priStrsender)
		{
			bool flag = false;
			string strServer = string.Empty;
			for (int i = 0; i < _priStrSender.Length; i++)
			{
				if (_priStrSender[i] == '@') { flag = true; i++; }
				if (flag == true) { strServer += _priStrSender[i]; }
			}
			return "smtp." + strServer;
		}

		public void Send(string strReceiver, string strEmailSubject, string strEmailBody)
		{
			try
			{
				using (var Message = new MailMessage(_priStrSender, strReceiver, strEmailSubject, strEmailBody))
				using (var client = new SmtpClient(_priStrServer) { EnableSsl = true, Credentials = new NetworkCredential(_priStrUser, _priStrPassword) })
				{
					client.Send(Message);
				}
			}
			catch
			{
				MessageBox.Show("Возникла ошибка при отправке сообщения");
				throw new Exception("Возникла ошибка при отправке сообщения");
			}
			finally
			{
				MessageBox.Show("Сообщение отправлено");
			}
		}
	}
}

