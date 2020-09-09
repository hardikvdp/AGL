using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Web.Repository;
using AGL.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AGL.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAGLRepository _aglRepository;

        public HomeController(IAGLRepository aglRepository)
        {
            _aglRepository = aglRepository;
        }
        public IActionResult Index()
        {
            var _persons = _aglRepository.GetPeronsWithCats();
            var grpd = _persons.GroupBy(x => x.Gender);
            var result = grpd.Select(x => new HomeViewModel
            {
                Gender = x.Key,
                Cats = x.SelectMany(item => item.Pets).Distinct().OrderBy(y => y.Name).ToList()
            }).ToList();
            return View(result);
        }
    }
}
