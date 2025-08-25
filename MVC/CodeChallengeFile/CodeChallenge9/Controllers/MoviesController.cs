using System;
using System.Net;
using System.Web.Mvc;
using CodeChallenge9.Models;
using CodeChallenge9.Repository;

namespace CodeChallenge9.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepo;

        public MoviesController()
        {
            _movieRepo = new MovieRepository();
        }

        public ActionResult Index()
        {
            var movies = _movieRepo.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _movieRepo.GetById(id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _movieRepo.GetById(id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _movieRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ByYear(int year)
        {
            var movies = _movieRepo.GetByYear(year);
            return View("Index", movies);
        }

        public ActionResult ByDirector(string name)
        {
            var movies = _movieRepo.GetByDirector(name);
            return View("Index", movies);
        }
    }
}
