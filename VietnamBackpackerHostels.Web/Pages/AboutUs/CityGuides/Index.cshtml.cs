using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamBackpackerHostels.Web.Pages.AboutUs.CityGuides
{
    public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, city guides, Ho Chi Minh City, Hanoi, Vietnam travel, backpacker travel, city attractions";
        }

        public override string MetaDescription()
        {
            return "Discover the best of Vietnam's vibrant cities with Vietnam Backpacker Hostels' city guides. Explore the top attractions, restaurants, and nightlife spots in Ho Chi Minh City, Hanoi, and more.";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetDataAsync();

            ViewData["Title"] = "City Guides";

            return Page();
        }
    }
}
