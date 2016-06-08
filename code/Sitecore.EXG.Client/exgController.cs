using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Sitecore.EXG.Client
{
  using System;
  using System.Web.Http;

  [ServicesController("ExgData")]
  public class exgController : ServicesApiController

  {
    private static readonly Random getrandom = new Random();

    private string GetRandomNumber()
    {
      return getrandom.Next(0, 100).ToString();
    }

    [HttpGet]
    public string Dashboard()
    {
      var output = "{ data: { visitsPerChannel: [ " + "{ \"label\": \"LandingPages\", \"value\": " + GetRandomNumber()
                   + " }," + "{ \"label\": \"RefURLs\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Search\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Campaigns\", \"value\": " + GetRandomNumber() + " },"
                   + "{ \"label\": \"Other\", \"value\": " + GetRandomNumber() + " }" + "]," + "monthlyDistribution: ["
                   + "{" + "key: \"Monthly Distribution\"," + "values: [" + "{ \"label\": \"January\", \"value\": "
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
                   + "{ \"label\": \"December\", \"value\":" + GetRandomNumber() + " }" + "]" + "}" + "]" + "}";

      return output;
    }


    [HttpGet]
    public string Outcomes()
    {
      var output = " { id: 1, category: 'Identification', label: 'Contact Acquisition', value: 0.3 },"
                   + " { id: 2, category: 'Lead Management Funnel', label: 'Close - Cancelled', value: 0.1 },"
                   + " { id: 3, category: 'Lead Management Funnel', label: 'Close - Lost', value: 0 },"
                   + " { id: 4, category: 'Lead Management Funnel', label: 'Close - Won', value: 0.8 },"
                   + " { id: 5, category: 'Lead Management Funnel', label: 'Marketing Lead', value: 0.4 },"
                   + " { id: 6, category: 'Lead Management Funnel', label: 'Opportunity', value: 0.2 },"
                   + " { id: 7, category: 'Lead Management Funnel', label: 'Sales Lead', value: 0.6 },"
                   + " { id: 8, category: 'Purchase', label: 'Product Purchase', value: 1 }";

      return output;
    }


  }
}
