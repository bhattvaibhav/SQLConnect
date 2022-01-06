using Microsoft.EntityFrameworkCore;
using SQLConnect.Modal;

namespace Emp.Repository
{
	public class EmpContext : DbContext, IEmpContext
	{
		public EmpContext(DbContextOptions<EmpContext> options)
			: base(options)
		{

		}

		public DbSet<Employee> Employee { get; set; }
	}
}
