using Microsoft.EntityFrameworkCore;
using SQLConnect.Modal;

namespace Emp.Repository
{
	public interface IEmpContext
	{
		#region DB Sets
		public DbSet<Employee> Employee { get; set; }

		#endregion

	}
}
