using Microsoft.EntityFrameworkCore;
using WebApi.Net.Models;

namespace WebApi.Net.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ITIContext _context;

        public DepartmentRepository(ITIContext context) 
        {
        _context = context;
        }

        public IEnumerable<Department> DisplayAll()
        {
            return _context.Department.Include(d=>d.Emps).ToList();
        }

        public void AddDept(Department department)
        {
          _context.Department.Add(department);
        }

        public void UpdateDept(Department department)
        {
            _context.Department.Update(department);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Department GetById(int id)
        {
           return _context.Department.FirstOrDefault(x=>x.Id==id);
        }

        public Department GetByName(string name)
        {
            return _context.Department.FirstOrDefault(x => x.Name == name);
        }
    }
}
