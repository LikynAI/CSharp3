using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.ValidationRules
{
	public class Name : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (!(value is string name)) return new ValidationResult(false, "Неккоректные данные");
			if (!Regex.IsMatch(name, @"[^0-9]{3,30}"))
				return new ValidationResult(false, "Введен некорректный адрес");
			return ValidationResult.ValidResult;
		}
	}
}