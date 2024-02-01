using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Redis_Usage_Example.Models;
using Redis_Usage_Example.Services;

namespace Redis_Usage_Example.Controllers;

[ApiController]
[Route("")]
public class PersonsController(ICacheService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]string key)
    {
        var data = await service.GetAsync<Person>(key);

        return Ok(data);
    }

    [HttpPost("/post")]
    public async Task<IActionResult> Post([FromBody] Person person, [FromQuery]string key)
    {
        await service.SetAsync(key, person);

        return Ok(await service.GetAsync<Person>(key));
    }
}