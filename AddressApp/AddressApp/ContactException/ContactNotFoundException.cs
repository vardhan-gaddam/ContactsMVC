using System.Runtime.Serialization;

namespace AddressApp.ContactsException
{
	public class ContactNotFoundException : Exception
	{
		public ContactNotFoundException(string? message)
			: base(message)
		{

		}
		public ContactNotFoundException()
	   : base()
		{
		}
		public ContactNotFoundException(string? message, Exception? innerException)
			: base(message, innerException)
		{
		}

		protected ContactNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
