using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender.Services
{
	public class DataBaseAccessservice : IDataAccessService
	{
		public ObservableCollection<Email> Emails
		{
			get
			{
				ObservableCollection<Email> Emails = new ObservableCollection<Email>();
				for (int i = 1; i < 31; i+=2)
				{
					Emails.Add(new Email($"{i}_Adress", $"{i}_Name", i));
				}
				return Emails;
			}
		}

		int IDataAccessService.CreateEmail(Email email)
		{
			return 0;
		}
	}
}
