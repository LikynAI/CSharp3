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
		public List<Email> emailDBContainerCollection
		{
			get
			{
				return emailDBContainer.Emails.ToList<Email>();
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

		int IDataAccessService.RefreshEmail(Email email)
		{
			throw new NotImplementedException();
		}

		int IDataAccessService.DeleteEmail(Email email)
		{
			try
			{

				emailDBContainer.Emails.Remove(email);
				emailDBContainer.SaveChanges();
				return 1;
			}
			catch
			{
				return 0;
			}
		}
	}
}
