using Microsoft.AspNetCore.Mvc;

namespace Redis_Usage_Example;

public class PersonsController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}