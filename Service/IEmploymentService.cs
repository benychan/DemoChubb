using Empleados.Models;
using Empleados.Repository;

namespace Empleados.Service
{
    public interface IEmploymentService
    {
        Task<IEnumerable<Empleado>> GetEmpleados();

        Task<Empleado> GetEmpleado(int id);

        void CreateEmpleado(Empleado emp);
        void UpdateEmpleado(int id, Empleado emp);

        void DeleteEmpleado(int id);
    }
}
