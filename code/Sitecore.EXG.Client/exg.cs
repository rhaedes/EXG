using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Web.Http;

namespace Sitecore.EXG.Client
{

  [ServicesController("api/exg")] 
  
    public class exg: ServicesApiController

    {
      public string Dashboard()
      {
        var output = "{ data: { visitsPerChannel: [ " + "{ \"label\": \"LandingPages\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"RefURLs\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"Search\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"Campaigns\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"Other\", \"value\": getRandomNumber() }" + "]," + "monthlyDistribution: [" + "{"
                     + "key: \"Monthly Distribution\"," + "values: ["
                     + "{ \"label\": \"January\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"February\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"March\", \"value\":getRandomNumber() },"
                     + "{ \"label\": \"April\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"Maj\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"June\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"July\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"August\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"September\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"October\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"November\", \"value\": getRandomNumber() },"
                     + "{ \"label\": \"December\", \"value\":getRandomNumber() }" + "]" + "}" + "]" + "}";

        return output;
      }

    }
}
