using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Bakery.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager, BakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    [HttpGet("/")]
    public ActionResult Index()
    {

      Dictionary<string, object[]> model = new Dictionary<string, object[]>();

        List<Flavor> flavors = _db.Flavors.ToList();

        List<Treat> treats = _db.Treats.ToList();

        model.Add("recipes", flavors.ToArray());
        model.Add("treats", treats.ToArray());


      return View(model);
    }
  }
}