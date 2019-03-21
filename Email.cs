using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class Email
    {
		public string Adress { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }

		public Email(){ }

		public Email(string Adress,string Name)
		{
			this.Adress = Adress;
			this.Name = Name;

		}
    }
}
