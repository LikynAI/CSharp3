using System;
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
	public partial class MainWindow : Window
	{
		private EmailSendServiceClass _emailSender;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex > 0)
			{
				MainTabControl.SelectedIndex--;
			}
		}

		private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex < MainTabControl.Items.Count)
			{
				MainTabControl.SelectedIndex++;
			}
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			KeyValuePair<string, string> item = (KeyValuePair<string, string>) cbSenderSelect.SelectionBoxItem;
			string strLogin = cbSenderSelect.Text;
			string strPassword = cbSenderSelect.SelectedValue.ToString();
			KeyValuePair<string, string> server = server = (KeyValuePair<string, string>)cbServerSelect.SelectionBoxItem;
			string strServer = cbServerSelect.Text;
			int iPort = Convert.ToInt16(cbServerSelect.SelectedValue);
			rtxMailBody.SelectAll();
			string mailbody = rtxMailBody.Selection.Text;
			if (string.IsNullOrEmpty(strLogin))
			{
				MessageBox.Show("Выберите отправителя");
				return;
			}
			if (string.IsNullOrEmpty(strPassword))
			{
				MessageBox.Show("Укажите пароль отправителя");
				return;
			}
			if (string.IsNullOrEmpty(mailbody))
			{
				MessageBox.Show("Письмо не содержит текста");
				MainTabControl.SelectedIndex = 2;
				return;
			}
			_emailSender = new EmailSendServiceClass(strLogin, strPassword, strServer, iPort, mailbody);
			_emailSender.SendMail("");
		}
	}
}
