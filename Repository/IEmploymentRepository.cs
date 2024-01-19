using Empleados.Models;

namespace Empleados.Repository
{
    public interface IEmploymentRepository
    {
        Task CreateEmployment(Empleado entity);
        Task DeleteEmployment(int id);
        Task<Empleado> GetEmployment(int id);        
        Task<IEnumerable<Empleado>> GetEmployments();
        Task updateEmployment(int id, Empleado entity);
    }
}