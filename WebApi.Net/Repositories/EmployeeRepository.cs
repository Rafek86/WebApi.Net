using WebApi.Net.Models;

namespace WebApi.Net.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ITIContext _context;

        public EmployeeRepository(ITIContext context) 
        {
        _context = context;
        }

        public IEnumerable<Employee> DisplayAll()
        {
            return _context.Employees.ToList();
        }

        public void AddDept(Employee employee)
        {
          _context.Employees.Add(employee);
        }

        public void UpdateDept(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
           return _context.Employees.FirstOrDefault(x=>x.Id==id);
        }

        public Employee GetByName(string name)
        {
            return _context.Employees.FirstOrDefault(x => x.Name == name);
        }
    }
}
