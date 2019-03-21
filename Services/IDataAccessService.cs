using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
	public interface IDataAccessService
	{
		List<Email> emailDBContainerCollection { get; }

		int CreateEmail(Email email);

		int RefreshEmail(Email email);

		int DeleteEmail(Email email); 
	}
}
