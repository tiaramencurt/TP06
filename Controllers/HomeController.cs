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
        return RedirectToAction("IrIniciarSesion");
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
    public IActionResult IrRegistrarse()
    {
        ViewBag.mailExiste = false;
        return View("Registrarse");
    }
    public IActionResult IrIniciarSesion()
    {
        ViewBag.mailExiste = true;
        ViewBag.contraseñaCoincide = true;
        return View("IniciarSesion");
    }
    public IActionResult IniciarSesion(string mail, string contraseña)
    {
        Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if(integrante == null)
        {
            integrante = BaseDatos.TraerIntegrante(mail);
            if (integrante == null)
            {
                ViewBag.mailExiste = false;
                ViewBag.contraseñaCoincide = true;
                return View("IniciarSesion");
            }
            else if (integrante.contraseña == contraseña)
            {
                HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
                return RedirectToAction("MostrarInfo");
            }
            else
            {
                ViewBag.mailExiste = true;
                ViewBag.contraseñaCoincide = false;
                return View("IniciarSesion");
            }
        }
        else
        {
            return RedirectToAction("Redirigir");
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
        if(integrante == null)
        {
            ViewBag.mailExiste = false;
            if(contraseña1 == contraseña2)
            {
                integrante = new Integrante(nombre, mail, contraseña1, nombreEquipo, apellido, genero, fechaNacimiento, datoCurioso, foto);
                BaseDatos.GuardarIntegrante(integrante);
                HttpContext.Session.SetString("integrante", Objeto.ObjectToString(integrante));
                return RedirectToAction("MostrarInfo");
            }
            return View("Registrarse");
        }else
        {
            ViewBag.mailExiste = true;
            return View("Registrarse");
        }
    }
    public IActionResult MostrarInfo()
    {
        Integrante integrante = Objeto.StringToObject<Integrante>(HttpContext.Session.GetString("integrante"));
        if(integrante != null)
        {
            List<Integrante> integrantes = BaseDatos.TraerIntegrantes(integrante);
            ViewBag.integrante = integrante;
            ViewBag.integrantes = integrantes;
        }else
        {
            return RedirectToAction("Redirigir");
        }
        return View("MostrarInfo");
    }
}
