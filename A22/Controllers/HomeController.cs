using A22.Data;
using System.Linq;
using System.Web.Mvc;
using A22.Models;
using System.Data.Entity;
using System;
using PagedList;
namespace A22.Controllers

{
    public class HomeController : Controller
    {
        private A22Context Db =new A22Context();
        public ActionResult Index(string category, string search,int?page,string sortBy)
        {
            ProductIndexViewModel viewModel = new ProductIndexViewModel();
            var products = Db.Products.Include(p => p.sp);
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search) ||
                p.Dscription.Contains(search) ||
                p.sp.Name.Contains(search));
                viewModel.Search = search;
            }
                viewModel.CatsWithCount = from matchingProducts in products
                                          where matchingProducts.sp != null
                                          group matchingProducts by
                                          matchingProducts.sp.Name into catGroup
                                          select new CategoryWithCount()
                                          {
                                              CategoryName = catGroup.Key,
                                              ProductCount = catGroup.Count()
                                          };
            if (!String.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.sp.Name == category);
                viewModel.Category = category;
            }
            switch (sortBy)
            {
                case "price_lowest":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_highest":
                    products=products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products=products.OrderBy(p => p.Name);
                    break;
            }
     
            const int PageItems = 8;
            int currentPage = (page ?? 1);
            viewModel.Products=products.ToPagedList(currentPage,PageItems); 
            viewModel.SortBy=sortBy;
            viewModel.Sorts = new System.Collections.Generic.Dictionary<string, string>
            {
                {"Price low to high","price_lowest" },
                {"Price high to low","price_heighest" }
            };
                return View(viewModel);


            }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}