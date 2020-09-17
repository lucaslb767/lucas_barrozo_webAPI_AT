using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/books", DataFormat.Json);
            var response = client.Get<List<Book>>(request);
            return View(response.Data);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/books/" + id, DataFormat.Json);
            var response = client.Get<Book>(request);
            return View(response.Data);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( BookResponse book )
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/books", DataFormat.Json);
                request.AddJsonBody(book);
                var response = client.Post<Book>(request);

                return Redirect("/book/index");
            }
            return BadRequest();
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/books/" + id, DataFormat.Json);
            var response = client.Get<Book>(request);

            return View(response.Data);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/books/" + id, DataFormat.Json);
                request.AddJsonBody(book);

                var response = client.Put<Book>(request);
                return Redirect("/book/index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/books/" + id, DataFormat.Json);
            var response = client.Get<Book>(request);

            return View(response.Data);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/books/" + id, DataFormat.Json);
                var response = client.Delete<Book>(request);

                return Redirect("/book");
            }
            catch
            {
                return View();
            }
        }
    }
}
