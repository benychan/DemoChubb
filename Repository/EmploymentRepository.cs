using Dapper;
using Empleados.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace Empleados.Repository
{
    public class EmploymentRepository : IEmploymentRepository
    {
        private readonly IConfiguration configuration;
        private readonly String connectionString;
        private const String CONNECTION_NAME = "DefaultConnectionString";

        
        public EmploymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString(CONNECTION_NAME); 
        }

        public async Task<IEnumerable<Empleado>> GetEmployments()
        {

            using var conn = new SqlConnection(this.connectionString);
            var sql = @"SELECT 
                        [Id], 
                        [Fotografia], 
	                    [Nombre] , 
	                    [Apellido] , 
	                    [PuestoId] , 
	                    [FechaNacimiento] , 
	                    [FechaContratacion] , 
	                    [Direccion] , 
	                    [Telefono] , 
	                    [CorreoElectronico] , 
	                    [EstadoId] 
                        from [Empleados]";
            return await conn.QueryAsync<Empleado>(sql);
        }

        public async Task<Empleado> GetEmployment(int id)
        {
            using var conn = new SqlConnection(this.connectionString);
            
            var sql = @"SELECT 
                        [Id],
                        [Fotografia], 
	                    [Nombre] , 
	                    [Apellido] , 
	                    [PuestoId] , 
	                    [FechaNacimiento] , 
	                    [FechaContratacion] , 
	                    [Direccion] , 
	                    [Telefono] , 
	                    [CorreoElectronico] , 
	                    [EstadoId] 
                        from [Empleados] WHERE Id = @id "; 
            return  await conn.QueryFirstAsync<Empleado>(sql, new { id });
        }

        public async Task CreateEmployment(Empleado entity)
        {
            using var conn = new SqlConnection(this.connectionString);

            var sql = @"INSERT INTO [Empleados]
                        (
                        [Fotografia], 
	                    [Nombre], 
	                    [Apellido], 
	                    [PuestoId], 
	                    [FechaNacimiento], 
	                    [FechaContratacion] , 
	                    [Direccion]  , 
	                    [Telefono],  
	                    [CorreoElectronico] , 
	                    [EstadoId]  
                        )
                        values (
                        @fotografia, 
	                    @nombre , 
	                    @apellido , 
	                    @puestoId, 
	                    @fechaNacimiento , 
	                    @fechaContratacion , 
	                    @direccion , 
	                    @telefono , 
	                    @correoElectronico , 
	                    @estadoId) 
                        ";
            await conn.QueryAsync(sql, new
            {
                fotografia = entity.Fotografia,
                nombre = entity.Nombre,
                apellido = entity.Apellido,
                puestoId = entity.PuestoId,
                fechaNacimiento = entity.FechaNacimiento,
                fechaContratacion = entity.FechaContratacion,
                direccion = entity.Direccion,
                telefono = entity.Telefono,
                correoElectronico = entity.CorreoElectronico,
                estadoId = entity.EstadoId
            });
        }

        public async Task updateEmployment(int id, Empleado entity)
        {
            using var conn = new SqlConnection(this.connectionString);

            var sql = @"UPDATE [Empleados] 
                        set 
                        [Fotografia]=@fotografia, 
	                    [Nombre] = @nombre , 
	                    [Apellido] = @apellido , 
	                    [PuestoId] = @puestoId, 
	                    [FechaNacimiento] = @fechaNacimiento , 
	                    [FechaContratacion] = @fechaContratacion , 
	                    [Direccion] = @direccion , 
	                    [Telefono] = telefono , 
	                    [CorreoElectronico] = @correoElectronico , 
	                    [EstadoId] = @estadoId 
                        WHERE Id = @id ";
            await conn.QueryAsync(sql, new { id, 
                fotografia=entity.Fotografia, 
                nombre=entity.Nombre,
                apellido=entity.Apellido, 
                puestoId=entity.PuestoId,
                fechaNacimiento=entity.FechaNacimiento,
                fechaContratacion=entity.FechaContratacion, 
                direccion=entity.Direccion,
                telefono=entity.Telefono, 
                correoElectronico = entity.CorreoElectronico,
                estadoId=entity.EstadoId
            });
        }

        public async Task DeleteEmployment(int id)
        {
            using var conn = new SqlConnection(this.connectionString);

            var sql = @"DELETE from [Empleados] WHERE Id = @id ";
            await conn.QueryAsync(sql, new { id});
        }
    }
}
