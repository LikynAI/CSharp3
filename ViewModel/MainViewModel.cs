using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
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
				if (!Set(ref _emails, value)) return;
				_emailsView = new CollectionViewSource { Source = value };
				_emailsView.Filter += OnEmailsCollectionViewSourceFilter;
				RaisePropertyChanged(nameof(EmailsView));
			}
		}

		private void OnEmailsCollectionViewSourceFilter(object sender, FilterEventArgs e)
		{
			if (!(e.Item is Email email) || string.IsNullOrWhiteSpace(_filterWord)) return;
			if (email.Name.Contains(_filterWord))
			{
				e.Accepted = true;
			}
			else if (email.Adress.Contains(_filterWord))
			{
				e.Accepted = true;
			}
			else if (email.Id.ToString().Contains(_filterWord))
			{
				e.Accepted = true;
			}
			else e.Accepted = false;
		}

		private string _filterWord;
		public string FilterWord
		{
			get => _filterWord;
			set
			{
				if (!Set(ref _filterWord, value)) return;
				EmailsView.Refresh();
			}
		}

		private CollectionViewSource _emailsView;
		public ICollectionView EmailsView => _emailsView?.View;

		public RelayCommand<Email> SaveEmailCommand { get; }
		public RelayCommand ReadAllMailsCommand { get; }

		public MainViewModel(IDataAccessService dataService)
		{
			_dataService = dataService;
			ReadAllMailsCommand = new RelayCommand(GetEmails);
			SaveEmailCommand = new RelayCommand<Email>(SaveEmail);
		}

		private Email _currentEmail = new Email();
		public Email CurrentEmail
		{
			get => _currentEmail;
			set => Set(ref _currentEmail, value);
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
