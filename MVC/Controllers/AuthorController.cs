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
    public class AuthorController : Controller
    {
        // GET: AuthorController
        public ActionResult Index()
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/authors", DataFormat.Json);
            var response = client.Get<List<Author>>(request);
            return View(response.Data);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/authors/" + id, DataFormat.Json);
            var response = client.Get<Author>(request);
            return View(response.Data);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                var client = new RestClient();

                var request = new RestRequest("https://localhost:5001/api/authors", DataFormat.Json);
                request.AddJsonBody(author);
                var response = client.Post<Author>(request);
                return Redirect("/author/index");
            }
            return BadRequest();
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/authors/" + id, DataFormat.Json);
            var response = client.Get<AuthorResponse>(request);

            return View(response.Data);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/authors/" + id, DataFormat.Json);
                request.AddJsonBody(author);
                var response = client.Put<Author>(request);

                return Redirect("/author/index");

            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:5001/api/authors/" + id, DataFormat.Json);
            var response = client.Get<Author>(request);

            return View(response.Data);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                var client = new RestClient();

                var request = new RestRequest("https://localhost:5001/api/authors/" + id, DataFormat.Json);
                var response = client.Delete<Author>(request);

                return Redirect("/author");
            }
            catch
            {
                return View();
            }
        }
    }
}
