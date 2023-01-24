using Employee_webApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_webApi.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
    { }
    public DbSet<Employee> employees { get; set; }
    public DbSet<CountryMst> CountryMst { get; set; }
    public DbSet<StateMst> StateMst { get; set; }
    public DbSet<CityMst> CityMst { get; set; }
  }
}
