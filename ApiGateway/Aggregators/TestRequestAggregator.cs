using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;

namespace ApiGateway.Aggregators
{
    public class TestRequestAggregator : IDefinedAggregator
    {
        private readonly ILogger _logger;

        public TestRequestAggregator(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            _logger.LogInformation("Calling {AggregatorName}", nameof(TestRequestAggregator));

            var results = responses.Select(x => x.Items.DownstreamResponse()).ToList();

            var contentList = new List<string>();
            foreach (var response in results)
            {
                var content = await response.Content.ReadAsStringAsync();
                contentList.Add(content);
            }

            return new DownstreamResponse(
                new StringContent(JsonConvert.SerializeObject(contentList)),
                HttpStatusCode.OK,
                results.SelectMany(x => x.Headers).ToList(), "OK");
        }
    }
}
