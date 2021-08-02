using EnergyCompanyConsoleApplication.Domain.Entities;
using System.Collections.Generic;

namespace EnergyCompanyConsoleApplication.Domain.Repositories
{
    public interface IEndpointRepository
    {
        bool Insert(Endpoint endpoint);
        bool Edit(Endpoint endpoint);
        bool Delete(Endpoint endpoint);
        IEnumerable<Endpoint> ListAll();
        Endpoint Find(string SerialNumber);
    }
}
