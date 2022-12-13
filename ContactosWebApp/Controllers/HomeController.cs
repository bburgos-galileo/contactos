using ContactosWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace ContactosWebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ContactosContext contactoContext;

        public HomeController(ContactosContext context)
        {
            contactoContext = context;
        }

        public IActionResult Index(string searchString)
        {
            List<Contacto> lista = new List<Contacto>();

            if (!String.IsNullOrEmpty(searchString))
            {
                lista = contactoContext.Contactos.Where(l => l.Nombre.Contains(searchString)).ToList();

                if (!lista.Any())
                {
                    lista = contactoContext.Contactos.ToList();
                }

            } else
            {
                lista = contactoContext.Contactos.ToList();
            }
            
            

            return View(lista);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View(new Contacto());
        }

        [HttpPost]
        public IActionResult Create(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contactoContext.Contactos.Add(contacto);
                contactoContext.SaveChanges();

                return Redirect("Index");
            }

            return View(contacto);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            List<Contacto> contacto = contactoContext.Contactos.Where(u => u.IdContacto.Equals(id)).ToList();

            return View(contacto[0]);
        }

        [HttpPost]
        public IActionResult Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contactoContext.Contactos.Update(contacto);
                contactoContext.SaveChanges();

                return Redirect("Index");
            }

            return View(contacto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            List<Contacto> contacto = contactoContext.Contactos.Where(u => u.IdContacto.Equals(id)).ToList();

            return View(contacto[0]);
        }

        [HttpPost]
        public IActionResult Delete(Contacto contacto)
        {
            contactoContext.Contactos.Where(u => u.IdContacto.Equals(contacto.IdContacto)).ExecuteDelete();
            contactoContext.SaveChanges();

            return Redirect("~/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}