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
		private readonly EmailDBContainer emailDBContainer = new EmailDBContainer();
		public ObservableCollection<Email> Emails
		{
			get
			{
				ObservableCollection<Email> Emails = emailDBContainer.Emails.Local;
				return Emails;
			}
		}

		int IDataAccessService.CreateEmail(Email email)
		{
			try
			{
				emailDBContainer.Emails.Add(email);
				emailDBContainer.SaveChanges();
				return emailDBContainer.Emails.Local.IndexOf(email);
			}
			catch
			{
				return 0;
			}
		}
	}
}
