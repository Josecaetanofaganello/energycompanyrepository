using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EnergyCompanyConsoleApplication.Infrastructure.Cache
{
    public class EndpointCacheRepository : IEndpointCacheRepository
    {
        private static readonly ConcurrentDictionary<string,Endpoint> _endpoints;

        static EndpointCacheRepository() => _endpoints = new ConcurrentDictionary<string, Endpoint>();

        public bool insert(Endpoint endpoint)
        {
            return _endpoints.TryAdd(endpoint.SerialNumber, endpoint);
        }
        public bool delete(Endpoint endpoint)
        {
            return _endpoints.TryRemove(endpoint.SerialNumber, out _);
        }

        public bool edit(Endpoint endpoint)
        {
            //find endpoint
            bool findResult = _endpoints.TryGetValue(endpoint.SerialNumber, out var _endpoint);
            //if exists , try update
            return findResult && _endpoints.TryUpdate(endpoint.SerialNumber, endpoint, _endpoint);
        }

        public Endpoint Find(string SerialNumber)
        {
            _endpoints.TryGetValue(SerialNumber, out var endpoint);
            return endpoint;
        }

        public IEnumerable<Endpoint> ListAll()
        {
            return _endpoints.Values;
        }
    }
}
