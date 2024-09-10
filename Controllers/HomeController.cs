using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortafolioNet6.Models;
using PortafolioNet6.Servicios;

namespace PortafolioNet6.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
    {
        _logger = logger;
        this.repositorioProyectos = repositorioProyectos;
    }

    public IActionResult Index()
    {
        // vamos a pasar datos a la vista como realmente debe ser, fuertemente tipado

        // hay una teoria que dice quen debe haber una responsabilidad unica en los controladores, y es normalmemte la de
        // despachar vistas, osea que instanciar clases como vemos a continuacion no seria lo mejor, lo mejor seria usar la inyeccion
        // de dependencias, para usar los mejores SOLID
        // Entonces lo inyectamos desde el constructor e hacemos la inyeccion de dependencias RepositorioProyectos
        // Y en el Program.cs debemos agregarlo builder.Services.AddTransient<RepositorioProyectos>();

        List<Proyecto> proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
        Persona persona = new Persona() { Nombre = "Helmuth", Apellido = "Sodetz Sánchez", Edad = 42 };

        var modelo = new HomeIndexViewModel()
        {
            Proyectos = proyectos,
            Persona = persona,

        };

        return View(modelo);
    }

    public IActionResult Proyectos()
    {
        List<Proyecto> proyectos = repositorioProyectos.ObtenerProyectos();

        // ahora pasasmos el modelo
        return View(proyectos);
    }

    // Este es un atributo que se coloca para el tipo de peticion, cuando es get no es necesario colocarlo
    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contacto(ContactoViewModel contactoViewModel)
    {
        return RedirectToAction("Gracias");
    }

    public IActionResult Gracias()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        // podemos pasar datos a la vista con ViewBag, lo malo de este es q no es fuertemente tipado
        // el Viewbag es de tipo dynamic, osea que le podemos pasar cualquier propiedad, cmo en este caso nombre y apellido
        // el mismo lo renderizamos en la vista
        ViewBag.Nombre = "Helmuth";
        ViewBag.Apellido = "Sodetz Sánchez";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

