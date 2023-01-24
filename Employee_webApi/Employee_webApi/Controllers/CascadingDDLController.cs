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
  public class CascadingDDLController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    public CascadingDDLController(ApplicationDbContext context)
    {
      _context = context;
    }

    [Route("GetAllCountry")]
    [HttpGet]
    public ActionResult<List<CountryMst>> GetAllCountry()
    {
      var countryList = _context.CountryMst.ToList();
      return Ok(countryList);

    }

    [Route("GetStateId/{countryId}")]
    [HttpGet]
    public ActionResult<List<CountryMst>> GetStateBYId(int countryId)
    {
      var stateList = _context.StateMst.Where(a => a.CountryMstid == countryId)
        .Select(a => new { a.id, a.stateName });
      return Ok(stateList);
    }


    [Route("GetCityId/{stateId}")]
    [HttpGet]
    public ActionResult<List<CountryMst>> GetCityBYId(int stateId)
    {
      var cityList = _context.CityMst.Where(a => a.StateMstid == stateId).Select(a => new { a.id, a.CityName });
    return Ok(cityList);
    }

  }
}
