using hello_web_api.Converters;
using Newtonsoft.Json;

namespace hello_web_api
{
	public class Student
	{
		[JsonConverter(typeof(OnlyDateConverter))]
		public DateTime RegistrationDate { get; set; }
		public int Semester { get; set; }
		public string? Email { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int IndexNumber { get; set; }
	}
}