using System.Collections.Generic;

namespace MailSender
{
	public static class Ports
	{
		public static Dictionary<string, int> PortsDictionary { get; } = new Dictionary<string, int>
		{
			{"smtp.yandex.ru", 25},
			{"smtp.mail.ru", 25},
			{"smtp.gmail.com", 465 }
		};
	}
}
