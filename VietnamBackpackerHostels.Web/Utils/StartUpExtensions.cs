using System;
using Microsoft.AspNetCore.Rewrite;

namespace VietnamBackpackerHostels.Web.Utils
{
	public static class StartUpExtensions
	{
        public static IApplicationBuilder AddUrlRedirects(this IApplicationBuilder app)
        {
            var rewriteOptions = new RewriteOptions().AddRedirect("^the-hostels/hoi-an$", "hostels/hoi-an")
                .AddRedirect("^the-hostels/the-imperial-hue$", "hostels/hue")
                .AddRedirect("^eat-and-sleep/hue-hostel-and-sports-bar$", "hostels/hue")
                .AddRedirect("^sleep-and-eat/hue$", "hostels/hue")
                .AddRedirect("^eat-and-sleep/hoi-an-hostel$", "hostels/hoi-an")
                .AddRedirect("^sleep-and-eat/hoi-an$", "hostels/hoi-an")
                .AddRedirect("^ha-long-bay/(.*)", "explore")
                //castaways
                .AddRedirect("^explore/castaways-island$", "explore")
                // buffalo run start
                .AddRedirect("^explore/buffalo-run$", "explore/tour/buffalo-run")
                .AddRedirect("^explore/the-north/buffalo-run$", "explore/tour/buffalo-run")
                .AddRedirect("^multi-destination-packages/buffalo-run-hanoi-to-hoi-an$", "explore/tour/buffalo-run")
                // buffalo run end
                // hai van pass start
                .AddRedirect("^explore/hai-van-pass$", "explore/category/hai-van-pass")
                .AddRedirect("^explore/central-highlands/hai-van-pass$", "explore/category/hai-van-pass")
                // hai van pass end
                // mai chau start
                .AddRedirect("^explore/mai-chau-valley$", "explore/category/mai-chau-valley")
                .AddRedirect("^explore/the-north/mai-chau-valley$", "explore/category/mai-chau-valley")
                .AddRedirect("^mai-chau/(.*)", "explore/category/mai-chau-valley")
                .AddRedirect("^mai-chau$", "explore/category/mai-chau-valley")
                // mai chau end
                // sapa start
                .AddRedirect("^explore/sapa$", "explore/category/sapa")
                .AddRedirect("^explore/the-north/sapa$", "explore/category/sapa")
                .AddRedirect("^sapa-the-northwest/(.*)", "explore/category/sapa")
                .AddRedirect("^sapa-the-northwest$", "explore/category/sapa")
                // sapa end
                .AddRedirect("^multi-destination-packages/(.*)", "explore")
                .AddRedirect("^multi-destination-packages$", "explore")
                .AddRedirect("^the-hostels/(.*)", "hostels")
                .AddRedirect("^the-hostels$", "hostels")
                .AddRedirect("^eat-and-sleep/(.*)", "hostels")
                .AddRedirect("^eat-and-sleep$", "hostels")
                .AddRedirect("^sleep-and-eat/(.*)", "hostels")
                .AddRedirect("^sleep-and-eat$", "hostels")
                .AddRedirect("^trips$", "explore")
                .AddRedirect("^extra-services$", "services")
                .AddRedirect("^more/(.*)", "services/$1")
                .AddRedirect("^more$", "services")
                .AddRedirect("^get-in-touch$", "contact")
                .AddRedirect("^contact-us$", "contact")
                .AddRedirect("^city-guide$", "about-us/city-guides")
                .AddRedirect("^city-guides$", "about-us/city-guides")
                .AddRedirect("^community$", "about-us/community")
                .AddRedirect("^join-our-crew$", "about-us/join-our-crew");

            List<Tuple<string, string>> redirects = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("explore/central-vietnam/bach-ma-national-park", "explore/tour/bach-ma-national-park"),
                new Tuple<string, string>("explore/central-vietnam/the-buffalo-run", "explore/tour/the-buffalo-run"),
                new Tuple<string, string>("explore/central-vietnam/hidden-hue", "explore/category/hidden-hue"),
                new Tuple<string, string>("explore/central-vietnam/hai-van-pass", "explore/category/hai-van-pass"),
                new Tuple<string, string>("explore/central-vietnam/hue-hoi-an-combo", "explore/tour/hue-hoi-an-combo"),
                new Tuple<string, string>("explore/central-vietnam/dmz-tour", "explore/tour/dmz-tour"),
                new Tuple<string, string>("explore/hanoi/the-buffalo-run", "explore/tour/the-buffalo-run"),
                new Tuple<string, string>("explore/hanoi/hanoi-introductory", "explore/tour/hanoi-introductory"),
                new Tuple<string, string>("explore/hanoi/ninh-binh", "explore/tour/ninh-binh"),
                new Tuple<string, string>("explore/hanoi/coffee-lovers-walking-tour", "explore/tour/coffee-lovers-walking-tour"),
                new Tuple<string, string>("explore/hanoi/bia-hoi-local-beer-crawl", "explore/tour/bia-hoi-local-beer-crawl"),
                new Tuple<string, string>("explore/north-to-south", "explore/category/north-to-south"),
                new Tuple<string, string>("explore/north-to-south/ha-long-bay-cruise", "explore/category/ha-long-bay-cruise"),
                new Tuple<string, string>("explore/the-north", "explore/category/the-north"),
                new Tuple<string, string>("explore/the-north/mai-chau-valley", "explore/category/mai-chau-valley"),
                new Tuple<string, string>("explore/the-north/sapa", "explore/category/sapa"),
            };

            foreach (var redirect in redirects)
            {
                rewriteOptions.AddRedirect($"^{redirect.Item1}$", redirect.Item2);
            }

            app.UseRewriter(rewriteOptions);
            
            return app;
        }
    }
}

