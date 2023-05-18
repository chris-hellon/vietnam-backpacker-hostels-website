using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VietnamBackpackerHostels.Web.Pages.TripsAndTravel
{
	public class IndexModel : TravaloudBasePageModel
    {
        public override Guid? PageId()
        {
            return new Guid("A723E122-C583-42BC-B565-EE860AE11712");
        }

        public override string MetaKeywords()
        {
            return "Vietnam Backpacker Hostels, Vietnam travel, Vietnam tours, backpacker travel, adventure travel, travel activities, backpacker-friendly, budget-friendly travel";
        }

        public override string MetaDescription()
        {
            return "Get the most out of your Vietnam travel experience with Vietnam Backpacker Hostels. Browse our range of tours, travel options, and activities to create your perfect itinerary.\n\n";
        }

        [BindProperty]
        public PageCategoryComponent Cards { get; private set; }

        [BindProperty]
        public GenericCardsComponent DestinationsCards { get; private set; }

        private readonly IDapperRepository<TourWithCategory> _toursWithCategoriesRepository;

        public IndexModel(IDapperRepository<TourWithCategory> toursWithCategoriesRepository)
        {
            _toursWithCategoriesRepository = toursWithCategoriesRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await OnGetDataAsync();

            var tours = await _toursWithCategoriesRepository.GetListAsync("GetTopLevelToursWithCategories", new
            {
                TenantId
            });

            tours = tours.Select(x =>
            {
                x.TourPrices = TourPrices.Where(tp => tp.TourId == x.Id);
                return x;
            });

            SetToursPrices(tours, Tours.SelectMany(x => x.TourPrices), ToursWithCategories);

            var pageSortings = PageSortings.Where(x => x.PageId == PageId());

            if (pageSortings.Any())
            {
                tours = tours.Select(x =>
                {
                    if (pageSortings.Any(ps => ps.TourCategoryId == x.Id))
                    {
                        x.SortOrder = pageSortings.First(ps => ps.TourCategoryId == x.Id).SortOrder;
                    }
                    else if (pageSortings.Any(ps => ps.TourId == x.Id))
                    {
                        x.SortOrder = pageSortings.First(ps => ps.TourId == x.Id).SortOrder;
                    }

                    return x;
                }).OrderBy(x => x.SortOrder);
            }

            Cards = WebComponentsBuilder.VietnamBackpackerHostels.GetToursWithCategoriesAndDestinationsPageCategoryComponent(tours);
            DestinationsCards = WebComponentsBuilder.VietnamBackpackerHostels.GetDestinationsGenericCards(Destinations);

            ViewData["Title"] = "Trips & Travel";

            return Page();
        }
    }
}
