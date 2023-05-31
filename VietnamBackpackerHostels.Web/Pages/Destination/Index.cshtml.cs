﻿using Travaloud.Core.Extensions;
namespace VietnamBackpackerHostels.Web.Pages.Destination
{
	public class IndexModel : TravaloudBasePageModel
    {
        public override string MetaKeywords()
        {
            if (DestinationProperty == null || string.IsNullOrEmpty(DestinationProperty.MetaKeywords))
                return "budget hostels, cheap hostels, backpackers hostels, Vietnam travel";

            return DestinationProperty.MetaKeywords;
        }

        public override string MetaDescription()
        {
            if (DestinationProperty == null || string.IsNullOrEmpty(DestinationProperty.MetaDescription))
                return "Our budget hostels in Vietnam offer comfortable and affordable accommodation for backpackers and budget travelers. Book now and start your Vietnam adventure!";

            return DestinationProperty.MetaDescription;
        }

        public override string MetaImageUrl()
        {
            if (DestinationProperty == null || BannerImages == null || BannerImages.Count == 0)
                return base.MetaImageUrl();

            return BannerImages.First();
        }

        [BindProperty]
        public DestinationDto Destination { get; private set; }

        [BindProperty]
        public IEnumerable<PropertyDto> DestinationProperties { get; private set; }

        [BindProperty]
        public PropertyDetailsDto DestinationProperty { get; private set; }

        [BindProperty]
        public BookNowComponent BookNowComponent { get; private set; } = null;

        [BindProperty]
        public CarouselCardsComponent ToursCarousel { get; private set; }

        [BindProperty]
        public List<string> BannerImages { get; private set; }

        [BindProperty]
        public CarouselComponent ImagesCarousel { get; private set; }

        public async Task<IActionResult> OnGetAsync(string destinationName)
        {
            await base.OnGetDataAsync();

            Destination = Destinations.FirstOrDefault(x => x.FriendlyUrl == destinationName);

            if (Destination != null)
            {
                ViewData["Title"] = Destination.Name;
                ViewData["SubTitle"] = "Hostels";

                DestinationProperties = await ApplicationRepository.GetDestinationPropertiesAsync(Destination.Id, TenantId);
                DestinationProperty = await ApplicationRepository.GetPropertyWithDetailsAsync(DestinationProperties.First().Id);

                BookNowComponent = new BookNowComponent(Properties, DestinationProperty.Id, false);

                if (DestinationProperty.Tours != null && DestinationProperty.Tours.Any())
                {
                    var tourIds = DestinationProperty.Tours.Select(x => x.Id);

                    ToursCarousel = WebComponentsBuilder.VietnamBackpackerHostels.GetToursCarouselCards(Tours.Where(x => tourIds.Contains(x.Id)), "", $"Tours In {Destination.Name}");
                }

                if (DestinationProperty.Images.Any())
                {
                    BannerImages = DestinationProperty.Images.Select(x => x.ImagePath.FormatImageUrl(800, "vbh")).ToList();
                }
                else
                {
                    switch (DestinationProperty.Id.ToString().ToUpper())
                    {
                        case "28A70CA0-1D20-4880-9737-21AD1DFFEA82": // hue

                            BannerImages = new List<string>();
                            for (int i = 0; i < 4; i++)
                            {
                                BannerImages.Add($"https://travaloudcdn.azureedge.net/vbh/assets/images/hue-banner-{i + 1}.webp?w=800");
                            }
                            break;
                        case "E4DCD399-2CAE-4F7A-9041-0D7A27B52773": // hoi an

                            BannerImages = new List<string>();
                            for (int i = 0; i < 6; i++)
                            {
                                BannerImages.Add($"https://travaloudcdn.azureedge.net/vbh/assets/images/hoi-an-banner-{i + 1}.webp?w=800");
                            }
                            break;
                        case "EEBE2058-C696-4C08-9641-062E092A524F":

                            BannerImages = new List<string>() { "https://travaloudcdn.azureedge.net/vbh/assets/images/hanoi-background-image.webp?w=800" };
                            break;
                    }

                }


                if (BannerImages != null && BannerImages.Any())
                    ImagesCarousel = new CarouselComponent("hostelBannerImages", BannerImages, true);
            }

            return Page();
        }
    }
}
