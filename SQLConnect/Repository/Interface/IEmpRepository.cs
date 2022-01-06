using SQLConnect.Modal;
using System.Collections.Generic;

namespace Emp.Repository
{
	public interface IEmpRepository
	{
		List<Employee> GetEmployeeList();
	}
}
