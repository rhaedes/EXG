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

    private string GetRandomNumber()
    {
      return getrandom.Next(0, 100).ToString();
    }
  }
}
