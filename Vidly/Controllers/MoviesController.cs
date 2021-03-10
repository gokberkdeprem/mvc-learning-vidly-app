using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Linq;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ViewResult Index()
        {

            var movie = _context.Movies.Include(m=>m.Genre).ToList();

            return View(movie);
        }

        public ActionResult Details(int Id)
        {

            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m=>m.ID == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
                {
                    new Customer{Name = " Customer 1"},
                    new Customer{Name = "Customer 2"}

                };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

            //***** For Education Purpose
            //return Content("hello world");
            //return HttpNotFound();
            //return new EmptyResult();//retruns an empty page
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }


        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{

        //    if (!pageIndex.HasValue) pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        //public ActionResult ByReleaseDate(int year, int month)
        //{

        //    return Content(year + "/" + month);

        //}

    }
}
