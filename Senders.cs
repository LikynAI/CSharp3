using System.Collections.Generic;
using CodePasswordDLL;

namespace MailSender
{
	public static class Senders
	{
		public static Dictionary<string, string> SendersDictionary { get; } = new Dictionary<string, string>
		{
			{"qwertyqq@gmail.com", Encrypter.Code("Password")},
			{"wasd@mail.ru", Encrypter.Code("Password2")}
		};
	}
}