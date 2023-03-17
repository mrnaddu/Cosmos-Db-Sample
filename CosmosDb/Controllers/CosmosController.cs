using CosmosDb.Data;
using CosmosDb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CosmosController : ControllerBase
{
    private readonly CosmosContext _context;

    public CosmosController(CosmosContext context)
    {
        _context = context;

    }

    [HttpPost]
    public ActionResult SaveEmployee()
    {
        var emp = new Employee()// Saving Data
        {
            Id = Guid.NewGuid(),
            Name = "nadeem",
            Date = DateTime.Now,
            Description = "CosmosTest"
        };
        _context.Add(emp);
        _context.SaveChanges();
        return Ok(emp);
    }

    [HttpGet]
    public ActionResult GetEmployee()
    {


        var emp = _context.Employees.ToList();
        return Ok(emp);
    }
}
