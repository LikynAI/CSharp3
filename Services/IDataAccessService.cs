using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
	public interface IDataAccessService
	{
		ObservableCollection<Email> Emails { get; }

		int CreateEmail(Email email);
	}
}
