using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using WebUi.Models;

namespace WebUi.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }
        // GET: Product
        [Route("product/list/{category}/{page}")]
        public ActionResult List(string category, int page = 1)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = _repository.GetAll()
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _repository.GetAll().Count() :
                       _repository.GetAll().Where(e => e.Category == category).Count()
                },
                Category = category
            };

            return View(productViewModel);
        }

        private IEnumerable<Product> GetProducts(string category, int page)
        {
            return _repository.GetAll()
                .Where(p => category == null || p.Category == category)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
        }
    }
}