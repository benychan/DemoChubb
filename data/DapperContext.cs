﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Empleados.data
{
    public class DapperContext
    {
        private readonly IConfiguration configuration;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection CreateConnection() {
            return new SqlConnection(configuration.GetConnectionString("DefaultConnectionString"));
        }

        public void Init() {
            using var connection = CreateConnection();

            InitDatabase();
            void InitDatabase() {
                var sql = @"
                create table Estados (
                Id int IDENTITY primary key, 
                Nombre varchar(100)
                ); 

                

                create table Puestos (
                Id int IDENTITY primary key, 
                Nombre varchar(100)
                );

                

                create table Empleados (
                Id int IDENTITY  primary key, 
                fotografia varchar(100), 
                Nombre varchar(100), 
                Apellido varchar(100), 
                PuestoId int, 
                FechaNacimiento date, 
                FechaContratacion date, 
                Direccion varchar(150), 
                Telefono varchar(13), 
                CorreoElectronico varchar(100), 
                EstadoId int, 
                Foreign key (PuestoId) references Puestos(Id),
                Foreign key (EstadoId) references Estados(Id)
                );

                

                Insert into Puestos (Nombre)
                values ('developer'), 
	                   ('scrum master'),  	
	                   ('pm'), 
	                   ('qa');


                Insert into Estados (Nombre)
                values ('Activo'), 
	                   ('Baja'), 
	                   ('Licencia'), 
	                   ('Pensionado');

                Insert into Empleados( 
	                fotografia , 
	                Nombre , 
	                Apellido , 
	                PuestoId , 
	                FechaNacimiento , 
	                FechaContratacion , 
	                Direccion , 
	                Telefono , 
	                CorreoElectronico , 
	                EstadoId 
                )
                values(
                'image/benito.jpg', 
                'Benito', 
                'Chan', 
                1, 
                '2024-01-01', 
                '2024-02-01', 
                '+5281000000',
                'Monterrey', 
                'benito@x.com',
                1
                ); 
            ";
                connection.ExecuteAsync(sql);
            }
        }
    }
}
