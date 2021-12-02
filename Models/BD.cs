using System;
using System.Data.SqlClient;
using Dapper;

namespace PadronAPI.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=DESKTOP-68PON6U\SQLEXPRESS;Database=BDPadron;Trusted_Connection=True;";

        public static Persona ConsultarPadron(int DNI)
        {
            Persona persona = null;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = @"  SELECT P.*, E.Nombre AS 'NombreEstablecimiento'
                                FROM Personas P
                                JOIN Establecimiento E ON E.IdEstablecimiento = P.IdEstablecimiento
                                WHERE P.DNI = @DNI
                            ";
                persona = connection.QueryFirstOrDefault<Persona>(query, new { DNI });
            }

            return persona;
        }

        public static Establecimiento ConsultarEstablecimiento(int id)
        {
            Establecimiento establecimiento = null;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Establecimiento WHERE IdEstablecimiento = @id";
                establecimiento = connection.QueryFirstOrDefault<Establecimiento>(query, new { id });
            }

            return establecimiento;
        }

        public static bool Votar(Voto voto)
        {
            bool status = false;

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Personas SET Voto = 1, FechaVotacion = @FechaVotacion WHERE DNI = @DNI";
                var affectedRows = connection.Execute(query, new { voto.DNI, FechaVotacion = DateTime.Now });

                if(affectedRows > 0)
                    status = true;
            }

            return status;
        }
    }
}
