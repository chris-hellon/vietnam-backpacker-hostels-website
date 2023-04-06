using Travaloud.Core.Models.PageModels;

namespace VietnamBackpackerHostels.Web.Pages.Tour
{
    public class IndexModel : TourPageModel
    {
        public override string Subject()
        {
            return "Tour Booking Enquiry";
        }

        public override string TemplateName()
        {
            return "TourEnquiryTemplate";
        }

        public override string MetaKeywords()
        {
            if (Tour == null)
                return "budget hostels, cheap hostels, backpackers hostels, Vietnam travel";

            return Tour.MetaKeywords;
        }

        public override string MetaDescription()
        {
            if (Tour == null)
                return "Our budget hostels in Vietnam offer comfortable and affordable accommodation for backpackers and budget travelers. Book now and start your Vietnam adventure!";

            return Tour.MetaDescription;
        }

        public override string MetaImageUrl()
        {
            if (Tour == null)
                return base.MetaImageUrl();

            return Tour.ImagePath;
        }

        [BindProperty]
        public Travaloud.Core.Entities.Catalog.Tour Tour { get; set; }

        [BindProperty]
        public GenericCardsComponent RelatedToursCards { get; private set; }

        public override async Task<IActionResult> OnGetAsync(string tourName = null)
        {
            await OnGetDataAsync();

            Tour = Tours.FirstOrDefault(x => x.FriendlyUrl == tourName);

            if (Tour != null)
            {
                var relatedTours = ToursWithCategories.Where(t => t.Id != Tour.Id).ToList();
                relatedTours.Shuffle();
                relatedTours = relatedTours.Take(3).ToList();

                RelatedToursCards = WebComponentsBuilder.UncutTravel.GetToursWithCategoriesGenericCards(relatedTours, null, true);
                Tour.TourPrices = await ToursRepository.GetTourPrices(Tour.Id);
                Tour.TourItineraries = await ToursRepository.GetTourItineraries(Tour.Id);
                EnquireNowComponent = new EnquireNowComponent()
                {
                    TourName = Tour.Name
                };
            }

            return Page();
        }
    }
}
