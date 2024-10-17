namespace WebApi.Net.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string? ManagerName { get; set; } 

        public IEnumerable<Employee>? Emps { get; set; } =new List<Employee>();   
    }
}
