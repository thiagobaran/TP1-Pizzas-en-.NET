using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP1Dai.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP1Dai.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;
    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
    {
        Environment = environment;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        IActionResult   respuesta;
        List<Pizza>     entityList;

        entityList  = BD.GetPizzas();
        respuesta   = Ok(entityList);
        return respuesta;
    }
    [HttpGet("{ID}")]
    public IActionResult GetById(int ID)
    {
        IActionResult   respuesta = null;
        Pizza           entity;

        entity = BD.GetById(id);
        if (entity == null) {
            respuesta = NotFound();
        } else {
            respuesta = Ok(entity);
        }
        return respuesta;
    }
    [HttpPost]
    public IActionResult Create(Pizza pizza )
    {
        int             intRowsAffected;
        intRowsAffected = BD.InsertPizza(Pizza);
        return CreatedAtAction(nameof(Create), new { id = Pizza.ID }, Pizza);
    }
    [HttpPut("{ID}")]
    public int Update(int ID, Pizza pizza)
    {
        IActionResult   respuesta = null;
        Pizza           entity;
        int             intRowsAffected;

        if (id != pizza.Id) {
            respuesta =  BadRequest();
        } else {
        entity = BD.GetById(id);
        if (entity == null){
            respuesta = NotFound();
        } else {
            intRowsAffected = BD.UpdateById(pizza);
        if (intRowsAffected > 0){
            respuesta = Ok(pizza);
                        
        } else {
                respuesta = NotFound();
                }
        }
        }
            
        return respuesta;
    }
    [HttpDelete("{ID}")]
    public IActionResult DeleteById(int ID)
    {
        IActionResult   respuesta = null;
        Pizza           entity;
        int             intRowsAffected;
            
        entity = BD.GetById(id);
        if (entity == null){
            respuesta = NotFound();
        } else {
            intRowsAffected = BD.DeleteById(id);
            if (intRowsAffected > 0){
                respuesta = Ok(entity);
            } else {
                respuesta = NotFound();
            }
        }
        return respuesta;
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
