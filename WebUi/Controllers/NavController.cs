using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace WebUi.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository _repository;

        public NavController(IProductRepository repo)
        {
            _repository = repo;
        }

        [Route("menu/{category}")]
        public PartialViewResult Menu(string category = null)
        { 

            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = _repository.GetAll()
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}