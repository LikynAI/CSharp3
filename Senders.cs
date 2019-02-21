using System.Collections.Generic;

namespace MailSender
{
	public static class Senders
	{
		public static Dictionary<string, string> SendersDictionary { get; } = new Dictionary<string, string>
		{
			{"qwertyqq@gmail.com", "Password"},
			{"wasd@mail.ru", "Password2"}
		};
	}
}