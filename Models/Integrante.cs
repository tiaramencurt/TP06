using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06.Models;
public class Integrante
{
    [JsonProperty]
    public string contraseña {get; private set;}
    [JsonProperty]
    public string nombre {get; private set;}
    [JsonProperty]
    public string nombreEquipo {get; private set;}
    [JsonProperty]
    public string apellido {get; private set;}
    [JsonProperty]
    public string genero {get; private set;}
    [JsonProperty]
    public string mail {get; private set;}
    [JsonProperty]
    public DateTime fechaNacimiento {get; private set;}
    [JsonProperty]
    public string datoCurioso {get; private set;}
    [JsonProperty]
    public string foto {get; private set;}
    public Integrante(string n, string m, string c, string nE, string a, string g, DateTime fN, string dC, string f)
    {
        this.nombre = n;
        this.mail = m;
        this.contraseña = c;
        this.nombreEquipo = nE;
        this.apellido = a;
        this.genero = g;
        this.fechaNacimiento = fN;
        this.datoCurioso = dC;
        this.foto = f;
    }
    public Integrante()
    {
    }
}