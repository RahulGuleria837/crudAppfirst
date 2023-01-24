using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_webApi.Models
{
  public class CityMst
  {
    public int id { get; set; }
    public string CityName { get; set; }
    public StateMst StateMst { get; set; }
    public int StateMstid { get; set; }

  }
}
