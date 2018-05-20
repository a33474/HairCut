using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCut.Services.Interfaces;
using HairCut.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairCut.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        private readonly IClientService _clientService;
        public  ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }
        public ActionResult Index()
        {
            IEnumerable<ClientVm> clientVm = _clientService.GetClients();
            if (HttpContext.Request.Headers["x-requested-with"]=="XMLHttpRequest")
            {
                return PartialView(clientVm);
            }
            else
                return View(clientVm);
        }

        // GET: Client/Create
        public ActionResult CreateClient()
        {
            return View(new ClientVm());
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(ClientVm clientVm)
        {
            //using ()
            //{
            // DO I NEED TO CONECT WITH SQL ???

            if (ModelState.IsValid)
            {
                _clientService.AddOrUpdateClient(clientVm);
                return RedirectToAction("Index");
            }
            else
                return View(ModelState);
        }

        // GET: Client/Edit/5
        public ActionResult EditClient(int id)
        {
            ClientVm clientVm = _clientService.GetClient(x => x.Id == id);
            return View(clientVm);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(ClientVm clientVm)
        {
            if (ModelState.IsValid)
            {
                _clientService.AddOrUpdateClient(clientVm);
                return RedirectToAction("Index");
            }
            else
                return View(clientVm);

        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}