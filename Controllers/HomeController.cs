using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("IniciarSesion");
    }
    public IActionResult Redirigir()
    {
        Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if(integrante == null)
        {
            return View("IniciarSesion");
        }
        else
        {
            return View("MostrarInfo");
        }
    }
    public IActionResult IniciarSesion(string mail, string contraseña)
    {
        Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if(integrante != null)
        {
            return RedirectToAction("Redirigir");
        }
        else
        {
            integrante = BaseDatos.TraerIntegrante(mail);
            HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
            if(integrante == null)
            {
                ViewBag.mailExiste = false;
            }else
            {
                ViewBag.mailExiste = true;
            }
            if(integrante.contraseña == contraseña)
            {
                ViewBag.contraseñaCoincide = true;
            }else
            {
                ViewBag.contraseñaCoincide = false;
            }
            if(ViewBag.contraseñaCoincide && ViewBag.mailExiste)
            {
                return View("MostrarInfo");
            }else
            {
                return View("IniciarSesion");
            }
        }
    }
    public IActionResult Registrarse(string mail, string nombreEquipo, string contraseña1, string contraseña2, string nombre, string apellido, string genero, DateTime fechaNacimiento, string datoCurioso, string foto)
    {
        Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if(integrante != null)
        {
            return RedirectToAction("Redirigir");
        }
        integrante = BaseDatos.TraerIntegrante(mail);
        HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
        if(integrante == null)
        {
            ViewBag.mailExiste = false;
        }else
        {
            ViewBag.mailExiste = true;
        }
        if(!ViewBag.mailExiste)
        {
            if(contraseña1 == contraseña2)
            {
                integrante = new Integrante(nombre, mail, contraseña1, nombreEquipo, apellido, genero, fechaNacimiento, datoCurioso, foto);
                BaseDatos.GuardarIntegrante(integrante);
            }
        }
    }//HAY QUE TERMINAR ESTE METODO
}
