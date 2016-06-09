using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Sitecore.EXG.Client
{
  using System;
  using System.Web.Mvc;
  using Newtonsoft.Json;


  [ServicesController("ExgData")]
  public class exgController : ServicesApiController

  {
    private static readonly Random getrandom = new Random();

    private string GetRandomNumber()
    {
      return getrandom.Next(0, 100).ToString();
    }


    [System.Web.Http.HttpGet]
    public ActionResult Dashboard()
    {
      var output = "{ \"chartsData\": { \"visitsPerChannel\": [ " + "{ \"label\": \"LandingPages\", \"value\": " + GetRandomNumber()
                   + " }," + "{ \"label\": \"RefURLs\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Search\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Campaigns\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Other\", \"value\": " + GetRandomNumber() + " }" + "]," + "\"monthlyDistribution\": ["
                   + "{" + "\"key\": \"Monthly Distribution\"," + "\"values\": [" + "{ \"label\": \"January\", \"value\": "
                   + GetRandomNumber() + " }," + "{ \"label\": \"February\", \"value\": " + GetRandomNumber() + " },"
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
                   + "{ name: '123', value: 0.1 }," + "{ name: 'ABC', value: 0.1 },"
                   + "{ name: 'Social/Campaign', value: 0.1 }," + "{ name: 'Social/Facebook/Campaign', value: 0.1 },"
                   + "{ name: 'Social/Facebook/Facebook Content Messages', value: 0.1 },"
                   + "{ name: 'Social/Facebook/Facebook Goal Messages', value: 0.1 },"
                   + "{ name: 'Social/Facebook/Facebook Share Buttons', value: 0.1 },"
                   + "{ name: 'Social/Google Plus/Google Plus Share Buttons', value: 0.1 },"
                   + "{ name: 'Social/LinkedIn/LinkedIn Share Buttons', value: 0.1 },"
                   + "{ name: 'Social/Social Marketer/Social Marketer', value: 0.1 },"
                   + "{ name: 'Social/Twitter/Twitter Content Messages', value: 0.1 },"
                   + "{ name: 'Social/Twitter/Twitter Goal Messages', value: 0.1 },"
                   + "{ name: 'Social/Twitter/Twitter Share Buttons', value: 0.1 }," + "]" + "}";

      return new JsonResult { Data = JsonConvert.DeserializeObject(output) };
    }

  }
}
