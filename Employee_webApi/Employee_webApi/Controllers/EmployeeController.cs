using Employee_webApi.Data;
using Employee_webApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_webApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : Controller
  {
    private readonly ApplicationDbContext _context;
    public EmployeeController(ApplicationDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    public IActionResult GetEmployees()
    { return Ok(_context.employees.ToList());
    }
    [HttpPost]
    public IActionResult SaveEmployee([FromBody] Employee employee)
    {
      if (employee != null && ModelState.IsValid)
      {
        _context.employees.Add(employee);
        _context.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }
    [HttpPut]
    public IActionResult UpdateEmployee([FromBody] Employee employee)
    {
      if (employee != null && ModelState.IsValid)
      {
        _context.employees.Update(employee);
        _context.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }
    [HttpDelete ("{id:int}")] 
     public IActionResult DeleteEmployee(int id)
    {
      var employeeindb = _context.employees.Find(id);
      if (employeeindb == null) return NotFound();
      _context.employees.Remove(employeeindb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
