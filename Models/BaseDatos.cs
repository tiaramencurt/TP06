using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public static class BaseDatos
{
    private static string _connectionString = @"Server=localhost; DataBase=Integrantes; Integrated Security=True; TrustServerCertificate=True;";
    public Integrante TraerIntegrante(string mail)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante WHERE mail = @mail";
            integrante = connection.QueryFirstOrDefault<Integrante>(query, new {mail});
        }
        return integrante;
    }
}