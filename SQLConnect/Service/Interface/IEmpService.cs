using SQLConnect.Modal;
using System.Collections.Generic;

namespace Emp.Service
{
	public interface IEmpService
	{
		List<Employee> GetEmployeeList();
	}
}
