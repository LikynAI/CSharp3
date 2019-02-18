﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		EmailSendServiceClass Sender;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void SendBtn_Click(object sender, RoutedEventArgs e)
		{
			if (Sender == null)
			{
				Sender = new EmailSendServiceClass(UserTextBox.Text, PasswordTextBox.Text, SenderTextBox.Text);
			}
			Sender.Send(ReciverTextBox.Text, MailSubjectTextBox.Text, MailBodyTextBox.Text);
		}
	}
}
