﻿using DancingGoat.Configuration;
using Kentico.AspNetCore.LocalizedRouting.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DancingGoat.Controllers
{
    [LocalizedRoute(CultureConstants.EnglishCulture, "Partner")]
    [LocalizedRoute(CultureConstants.SpanishCulture, "Afiliados")]
    public class PartnerShipController : Controller
    {
        [LocalizedRoute(CultureConstants.EnglishCulture, "Index")]
        [LocalizedRoute(CultureConstants.SpanishCulture, "Indice")]
        public ActionResult Index()
        {
            ViewBag.PartnershipRequested = TempData["formApplied"] ?? false;
            return View();
        }

        /// <summary>
        /// Dummy action.
        /// </summary>
        [HttpPost]
        public ActionResult Application()
        {
            // If needed, put your code here to work with the uploaded data in MVC.
            TempData["formApplied"] = true;
            return RedirectToAction("Index");
        }
    }
}