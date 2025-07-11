using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace TP06.Models;

public static class BaseDatos
{
    private static string _connectionString = @"Server=localhost; DataBase=Integrantes; Integrated Security=True; TrustServerCertificate=True;";
    public static Integrante TraerIntegrante(string mail)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante WHERE mail = @mail";
            Integrante integrante = connection.QueryFirstOrDefault<Integrante>(query, new { mail });
            return integrante;
        }
    }
    public static void GuardarIntegrante(Integrante integrante)
    {
        string query = "INSERT INTO Integrante (mail, contraseña, nombre, nombreEquipo, apellido, genero, fechaNacimiento, datoCurioso, foto) VALUES (@pmail, @pcontraseña, @pnombre, @pnombreEquipo, @papellido, @pgenero, @pfechaNacimiento, @pdatoCurioso, @pfoto)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { pmail = integrante.mail, pcontraseña = integrante.contraseña, pnombre = integrante.nombre, pnombreEquipo = integrante.nombreEquipo, papellido = integrante.apellido, pgenero = integrante.genero, pfechaNacimiento = integrante.fechaNacimiento, pdatoCurioso = integrante.datoCurioso, pfoto = integrante.foto });
        }
    }
    public static List<Integrante> TraerIntegrantes(Integrante integrante)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante WHERE nombreEquipo = @pEquipo";
            List<Integrante> integrantes = connection.Query<Integrante>(query, new { pEquipo = integrante.nombreEquipo }).ToList();
            return integrantes;
        }
    }

}