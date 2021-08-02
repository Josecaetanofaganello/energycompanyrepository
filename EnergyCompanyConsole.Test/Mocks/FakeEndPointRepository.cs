using EnergyCompanyConsoleApplication.Domain.Entities;
using EnergyCompanyConsoleApplication.Domain.Enums;
using EnergyCompanyConsoleApplication.Domain.Repositories;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EnergyCompanyConsole.Test
{
    public class FakeEndPointRepository : IEndpointRepository
    {
        private static readonly ConcurrentDictionary<string, Endpoint> _fakeEndpoints;

        static FakeEndPointRepository()
        {
            _fakeEndpoints = new ConcurrentDictionary<string, Endpoint>();

            Endpoint end0 = new Endpoint("00000000001", (EMeterModel)16, 1, "1.0.0", (ESwitchState)1);
            Endpoint end1 = new Endpoint("00000000002", (EMeterModel)17, 1, "1.1.0", (ESwitchState)2);
            Endpoint end2 = new Endpoint("00000000003", (EMeterModel)18, 1, "1.0.0", (ESwitchState)1);
            Endpoint end3 = new Endpoint("00000000004", (EMeterModel)19, 1, "1.3.0", (ESwitchState)1);
            Endpoint end4 = new Endpoint("00000000005", (EMeterModel)16, 1, "1.2.0", (ESwitchState)0);
            _fakeEndpoints.TryAdd(end0.SerialNumber,end0);
            _fakeEndpoints.TryAdd(end1.SerialNumber,end1);
            _fakeEndpoints.TryAdd(end2.SerialNumber,end2);
            _fakeEndpoints.TryAdd(end3.SerialNumber,end3);
            _fakeEndpoints.TryAdd(end4.SerialNumber,end4);
        }

        public bool Insert(Endpoint endpoint)
        {
            return _fakeEndpoints.TryAdd(endpoint.SerialNumber, endpoint);
        }
        public bool Delete(Endpoint endpoint)
        {
            return _fakeEndpoints.TryRemove(endpoint.SerialNumber, out _);
        }

        public bool Edit(Endpoint endpoint)
        {
            //find endpoint
            bool findResult = _fakeEndpoints.TryGetValue(endpoint.SerialNumber, out var _endpoint);
            //if exists , try update
            return findResult && _fakeEndpoints.TryUpdate(endpoint.SerialNumber, endpoint, _endpoint);
        }

        public Endpoint Find(string SerialNumber)
        {
            _fakeEndpoints.TryGetValue(SerialNumber, out var endpoint);
            return endpoint;
        }

        public IEnumerable<Endpoint> ListAll()
        {
            return _fakeEndpoints.Values;
        }
    }
}
