using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Services;

namespace MailSender.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IDataAccessService _dataService;
		private ObservableCollection<Email> _emails = new ObservableCollection<Email>();

		public ObservableCollection<Email> Emails
		{
			get => _emails;
			set
			{
				Set(ref _emails, value);
			}
		}

		public RelayCommand<Email> SaveEmailCommand { get; }
		public RelayCommand ReadAllMailsCommand { get; }
		public RelayCommand<string> EmailsSortCommand { get; }

		public MainViewModel(IDataAccessService dataService)
		{
			_dataService = dataService;
			ReadAllMailsCommand = new RelayCommand(GetEmails);
			SaveEmailCommand = new RelayCommand<Email>(SaveEmail);
			EmailsSortCommand = new RelayCommand<string>(EmailsSort);
		}

		private Email _currentEmail = new Email();
		public Email CurrentEmail
		{
			get => _currentEmail;
			set => Set(ref _currentEmail, value);
		}

		private void EmailsSort(string word)
		{
			GetEmails();
			int changes = 0;
			for (int i = 0; i < Emails.Count; i++)
			{	
				bool change = false;
				for (int k = 0; k+word.Length < Emails[i].Name.Length; k++)
				{
					for (int j = 0; j < word.Length; j++)
					{
						if (Emails[i].Name[k] == word[j])
						{
							change = true;
						}
						else
						{
							change = false;
							break;
						}
						if (change)
						{
							Email tempo = Emails[i];
							for (int h = changes; h < i; h++)
							{
								Emails[i - h + changes] = Emails[i-h-1 + changes];
							}
							Emails[changes] = tempo;
							changes++;
						}
					}
				}
			}
		} 

		private void SaveEmail(Email email)
		{
			email.Id = _dataService.CreateEmail(email);
			if (email.Id == 0) return;
			Emails.Add(email);
		}

		private void GetEmails()
		{
			Emails = _dataService.Emails;
		}
	}
}
