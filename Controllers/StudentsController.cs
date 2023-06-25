using Microsoft.AspNetCore.Mvc;

namespace hello_web_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentsController : ControllerBase
	{

		private readonly ILogger<StudentsController> _logger;
		private readonly List<Student> _students = new() {
			new Student()
			{
				FirstName = "Patryk",
				LastName = "Filipczuk",
				IndexNumber = 329118,
				Semester = 2,
				Email = "patryk.filipczuk.stud@pw.edu.pl",
				RegistrationDate = new DateTime(2022, 10, 1)
			},
			new Student()
			{
				FirstName = "Mateusz",
				LastName = "Kedzierski",
				IndexNumber = 329124,
				Semester = 2,
				Email = "mateusz.kedzierski3.stud@pw.edu.pl",
				RegistrationDate = new DateTime(2022, 10, 1)
			}
		};

		public StudentsController(ILogger<StudentsController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<Student> Get()
		{
			_logger.LogInformation($"Returning student list: ${_students}");
			return _students;
		}
	}
}