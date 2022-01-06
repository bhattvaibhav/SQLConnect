using Emp.Repository;
using SQLConnect.Modal;
using System.Collections.Generic;
using System.Linq;

namespace SQLConnect.Repository
{
	public class EmpRepository: IEmpRepository
	{
		private readonly IEmpContext _empContext;
		public EmpRepository(IEmpContext empContext)
		{
			_empContext = empContext;
		}

		public List<Employee> GetEmployeeList()
		{
			return _empContext.Employee.ToList();
		}
	}
}
