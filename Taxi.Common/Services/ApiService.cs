using System;
using System.Threading.Tasks;
using Taxi.Common.Models;

namespace Taxi.Common.Services
{
    public class ApiService : IApiService
    {
        public Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller)
        {
            throw new NotImplementedException();
        }
    }
}
