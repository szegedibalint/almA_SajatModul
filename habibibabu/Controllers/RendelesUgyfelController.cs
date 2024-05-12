using Christoc.Modules.habibibabu.Components;
using Christoc.Modules.habibibabu.Models;
using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Christoc.Modules.habibibabu.Controllers
{
    [DnnHandleError]
    public class RendelesUgyfelController : DnnController
    {
        // GET: RendelesUgyfel
        public ActionResult Index()
        {
            var rendelesugyfelViewModel = new RendelesViewModel
            {
                RendelesUgyfel = new RendelesUgyfel() // Új rendelésügyfél létrehozása
            };

            return View(rendelesugyfelViewModel);
        }

        // Az Index akció, amely kezeli a form elküldését
        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Index(RendelesViewModel viewModel)
        {
            // Az adatok kezelése, például adatbázisba mentés
            RendelesManager.Instance.CreateRendelesUgyfel(viewModel.RendelesUgyfel);

            // rendeles tartalmazza a bekért adatokat
            // Utána lehet például átirányítani vagy frissíteni az oldalt
            return RedirectToDefaultRoute();
        }
    }
}