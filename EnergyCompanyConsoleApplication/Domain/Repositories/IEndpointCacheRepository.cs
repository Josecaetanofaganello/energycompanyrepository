using EnergyCompanyConsoleApplication.Domain.Entities;
using System.Collections.Generic;

namespace EnergyCompanyConsoleApplication.Domain.Repositories
{
    public interface IEndpointCacheRepository
    {
        bool insert(Endpoint endpoint);
        bool edit(Endpoint endpoint);
        bool delete(Endpoint endpoint);
        IEnumerable<Endpoint> ListAll();
        Endpoint Find(string SerialNumber);
    }
}
