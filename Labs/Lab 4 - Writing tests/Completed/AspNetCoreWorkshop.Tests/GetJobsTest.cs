using AspNetCoreWorkshop.Api.Jobs.GetJobs;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace AspNetCoreWorkshop.Tests
{
    class GetJobsTest : TestBase
    {
        [Test]
        public async Task Get_jobs_response_returns_all_data()
        {
            using (var server = CreateTestServer())
            {
                var client = server.CreateClient();
                var resp = await client.GetAsync("/api/jobs");
                Assert.That(resp.StatusCode, Is.EqualTo(HttpStatusCode.OK));

                var json = await resp.Content.ReadAsAsync<IEnumerable<GetJobsResponse>>();
                Assert.That(json.Any());
                Assert.AreEqual(2, json.Count());
            }
        }
    }
}
