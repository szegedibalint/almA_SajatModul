/*
' Copyright (c) 2024 Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

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
    public class RendelesController : DnnController
    {
        public ActionResult Index()
        {
            var rendeles = new Rendeles(); // Új rendelés létrehozása

            RendelesViewModel viewModel = new RendelesViewModel
            {
                Rendeles = rendeles,
                // További adatokat is hozzáadhatsz, ha szükséges
            };

            int rendelesSzam = RendelesManager.Instance.GetLastRendelesId() + 1;
            string rendelesSzamStr = DateTime.Now.ToString("yyyyMMdd") + "-" + rendelesSzam.ToString("D6");

            // Sikeres rendelés üzenetének frissítése
            string text = rendelesSzamStr;
            ViewBag.SwalText = text; // Az üzenet tárolása a TempData-ban

            return View(viewModel);
        }

        // Az Index akció, amely kezeli a form elküldését
        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Index(RendelesViewModel viewModel)
        {
            // Az adatok kezelése, például adatbázisba mentés
            viewModel.Rendeles.CreatedOnDate = DateTime.UtcNow.AddHours(2);

            RendelesManager.Instance.CreateRendeles(viewModel.Rendeles);

            // rendeles tartalmazza a bekért adatokat
            // Utána lehet például átirányítani vagy frissíteni az oldalt
            return RedirectToDefaultRoute();
        }

    }
}

