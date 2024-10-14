using WebApi.Net.Models;

namespace WebApi.Net.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> DisplayAll();
        Department GetById(int id);
        Department GetByName(string name);
        void AddDept(Department department);
        void UpdateDept(Department department);
        void Save();

    }
}
