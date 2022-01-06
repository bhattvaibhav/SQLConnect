using Emp.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLConnect.Controllers
{
	public class EmpController : Controller
	{
		private IEmpService _empService;
		public EmpController(IEmpService empService)
		{
			_empService = empService;
		}
		public IActionResult Index()
		{
			var empList = _empService.GetEmployeeList();
			return View(empList);
		}
	}
}
