﻿using System.Linq;
using System.Threading.Tasks;
using DancingGoat.Areas.Admin;
using DancingGoat.Models;
using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DancingGoat.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(IOptionsSnapshot<DeliveryOptions> deliveryOptions, AppSettingProvider settingProvider) 
            : base(deliveryOptions, settingProvider)
        {
        }

        public async Task<ActionResult> Index()
        {
            var response = await _client.GetItemAsync<Home>("home");

            var viewModel = new HomeViewModel
            {
                ContentItem = response.Item,
                Header = response.Item.HeroUnit.Cast<HeroUnit>().FirstOrDefault(x => x.System.Codename == "home_page_hero_unit"),
            };

            return View(viewModel);
        }

        // TODO: See how to use the ChildActionOnly filter
        public ActionResult CompanyAddress()
        {
            var contact = Task.Run(() => _client.GetItemAsync<Home>("home", new ElementsParameter("contact")))
                .GetAwaiter().GetResult().Item.Contact;

            return PartialView("CompanyAddress", contact);
        }
    }
}