using Empleados.Models;
using Empleados.Repository;

namespace Empleados.Service
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IEmploymentRepository repository;

        public EmploymentService(IEmploymentRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Empleado>> GetEmpleados() {
            return repository.GetEmployments();
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            var empleado= await repository.GetEmployment(id);
            if (empleado == null)
            {
                throw new KeyNotFoundException("user not found"); 
            }
            return empleado;
        }

        public void CreateEmpleado(Empleado emp)
        {
            repository.CreateEmployment(emp);
        }

        public void UpdateEmpleado(int id, Empleado emp) {
            repository.updateEmployment(id, emp);
        }

        public void DeleteEmpleado(int id)
        {
            repository.DeleteEmployment(id);
        }
    }
}
