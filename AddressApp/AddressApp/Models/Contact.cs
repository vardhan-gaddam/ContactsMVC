using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace AddressApp.Models
{
	[Table("ASPContactInformation")]
	public class Contact
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Landline { get; set; }
		public string Website { get; set; }
		public string Address { get; set; }
	}
}
