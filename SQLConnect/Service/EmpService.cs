using Emp.Repository;
using Emp.Service;
using SQLConnect.Modal;
using System.Collections.Generic;


namespace SQLConnect.Service
{
	public class EmpService : IEmpService
	{
		private IEmpRepository _empRepository;
		public EmpService(IEmpRepository empRepository)
		{
			_empRepository = empRepository;
		}

		public List<Employee> GetEmployeeList()
		{
			return _empRepository.GetEmployeeList();
		}
	}
}
