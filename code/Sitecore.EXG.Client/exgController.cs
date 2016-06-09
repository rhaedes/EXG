using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Sitecore.EXG.Client
{
  using System;
  using System.Globalization;
  using System.Web.Mvc;

  using Newtonsoft.Json;

  [ServicesController("ExgData")]
  public class exgController : ServicesApiController

  {
    private static double progress = 0.01;

    private static readonly Random getrandom = new Random();

    private string GetRandomNumber()
    {
      return getrandom.Next(0, 100).ToString();
    }

    [System.Web.Http.HttpGet]
    public ActionResult Dashboard()
    {
      var output = "{ \"chartsData\": { \"visitsPerChannel\": [ " + "{ \"label\": \"LandingPages\", \"value\": "
                   + GetRandomNumber() + " }," + "{ \"label\": \"RefURLs\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Search\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Campaigns\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Other\", \"value\": " + GetRandomNumber() + " }" + "],"
                   + "\"monthlyDistribution\": [" + "{" + "\"key\": \"Monthly Distribution\"," + "\"values\": ["
                   + "{ \"label\": \"January\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"February\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"March\", \"value\":" + GetRandomNumber() + " },"
                   + "{ \"label\": \"April\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Maj\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"June\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"July\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"August\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"September\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"October\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"November\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"December\", \"value\":" + GetRandomNumber() + " }" + "]" + "}" + "]" + "}}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

    [System.Web.Http.HttpGet]
    public ActionResult Outcomes()
    {
      var output = "[{ id: 1, category: 'Identification', label: 'Contact Acquisition', value: 0.3 },"
                   + " { id: 2, category: 'Lead Management Funnel', label: 'Close - Cancelled', value: 0.1 },"
                   + " { id: 3, category: 'Lead Management Funnel', label: 'Close - Lost', value: 0 },"
                   + " { id: 4, category: 'Lead Management Funnel', label: 'Close - Won', value: 0.8 },"
                   + " { id: 5, category: 'Lead Management Funnel', label: 'Marketing Lead', value: 0.4 },"
                   + " { id: 6, category: 'Lead Management Funnel', label: 'Opportunity', value: 0.2 },"
                   + " { id: 7, category: 'Lead Management Funnel', label: 'Sales Lead', value: 0.6 },"
                   + " { id: 8, category: 'Purchase', label: 'Product Purchase', value: 1 }]";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

    [System.Web.Http.HttpGet]
    public ActionResult Landingpages()
    {
      var output = "{id: 1, image: '/images/icons/home.png', label: 'Test 1', sliderValue: 0.2, items: [" + "{"
                   + "id: 2, image: '/images/icons/folder.png', label: 'Test 2', sliderValue: 0.1, items: ["
                   + "{ id: 3, image: '/images/icons/cubes_blue.png', label: 'Test 3', sliderValue: 0.7 },"
                   + "{ id: 4, image: '/images/icons/window_colors.png', label: 'Test 4', sliderValue: 0.4 }" + "]"
                   + "}," + "{ id: 5, image: '/images/icons/preferences.png', label: 'Test 5', sliderValue: 0.9 },"
                   + "{ id: 6, image: '/images/icons/workstation1.png', label: 'Test 6', sliderValue: 0.5 }" + "]" + "}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

    [System.Web.Http.HttpGet]
    public ActionResult Campaigns()
    {
      var output = "{" + "traffic: {" + "name: 'Campaign traffic'," + "value: 0.5" + "}," + "items: ["
                   + "{name: '123', value: 0.1 }," + "{name: 'ABC', value: 0.1 },"
                   + "{name: 'Social/Campaign', value: 0.1 }," + "{name: 'Social/Facebook/Campaign', value: 0.1 },"
                   + "{name: 'Social/Facebook/Facebook Content Messages', value: 0.1 },"
                   + "{name: 'Social/Facebook/Facebook Goal Messages', value: 0.1 },"
                   + "{name: 'Social/Facebook/Facebook Share Buttons', value: 0.1 },"
                   + "{name: 'Social/Google Plus/Google Plus Share Buttons', value: 0.1 },"
                   + "{name: 'Social/LinkedIn/LinkedIn Share Buttons', value: 0.1 },"
                   + "{name: 'Social/Social Marketer/Social Marketer', value: 0.1 },"
                   + "{name: 'Social/Twitter/Twitter Content Messages', value: 0.1 },"
                   + "{name: 'Social/Twitter/Twitter Goal Messages', value: 0.1 },"
                   + "{name: 'Social/Twitter/Twitter Share Buttons', value: 0.1 }," + "]" + "}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

    [System.Web.Http.HttpGet]
    public ActionResult Overview()
    {
      var output = "{" + "uniqueVisitorsNumber: {" + "name: 'Number of unique visitors'," + "value: 170" + "},"
                   + "generatedVisitsNumber: {" + "name: 'Number of visits generated (approx.)'," + "value: 100500"
                   + "}," + "bounceRate: {" + "name: 'Bounce rate'," + "  value: 0.5" + "},"
                   + " percentageIdentifiedVisitors: {" + "name: 'Percentage identified visitors'," + "value: 0.2"
                   + "}," + "peageviewsPerVisit: {" + "name: 'Pageviews per visit (avg)'," + "value: 4" + "},"
                   + "timeSpentPerVisit: {" + "name: 'Time spent per page (avg)'," + "value: '00:30'" + "},"
                   + "startDate: {" + "name: 'Start date'," + "value: '02/06/2015'" + "}," + "endDate: {"
                   + "name: 'End date'," + "value: '16/06/2015'" + "}," + "dailyDistribution: ["
                   + "{name: 'Monday', value: 0.1 }," + "{name: 'Tuesday', value: 0.1 },"
                   + "{name: 'Wednesday', value: 0.1 }," + "{name: 'Thursday', value: 0.1 },"
                   + "{name: 'Friday', value: 0.1 }," + "{name: 'Saturday', value: 0.1 },"
                   + "{name: 'Sunday', value: 0.1 }" + "]," + "monthlyDistribution: ["
                   + "{name: 'January', value: 0.1 }," + "{name: 'February', value: 0.1 },"
                   + "{name: 'March', value: 0.1 }," + "{name: 'April', value: 0.1 }," + "{name: 'May', value: 0.1 },"
                   + "{name: 'June', value: 0.1 }," + "{name: 'July', value: 0.1 }," + "{name: 'August', value: 0.1 },"
                   + "{name: 'September', value: 0.1 }," + "{name: 'October', value: 0.1 },"
                   + "{name: 'November', value: 0.1 }," + "{name: 'December', value: 0.1 }" + "],"
                   + "trafficDistribution: [" + "{name: 'micro', value: 0.4 }," + "{name: 'website', value: 1 }" + "],"
                   + "location: [" + "{name: 'Europe, Middle East, Africa', value: 0.3 },"
                   + "{name: 'Asia Pacific', value: 0.1 }," + "{name: 'Americas', value: 0.6 }" + "]" + "}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

    [System.Web.Http.HttpGet]
    public ActionResult Jobs()
    {

      progress += 0.05;

      if (progress > 1)
      {
        progress = 1;
      }

      var output = "{Id:123, CompletedVisitors:100, Segments:[], JobStatus:'Running', Progress: " + progress.ToString(CultureInfo.InvariantCulture) + ", CompletedVisits:501}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };

    }

  }
}
