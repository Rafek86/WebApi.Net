using WebApi.Net.Models;

namespace WebApi.Net.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> DisplayAll();
        Employee GetById(int id);
        Employee GetByName(string name);
        void AddDept(Employee employee);
        void UpdateDept(Employee employee);
        void Save();

    }
}
