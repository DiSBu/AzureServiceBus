using Common.Model.Entities;
using System.Collections.Generic;

namespace Common.Repository.DataRepository
{
    public interface IDataRepository
    {
        IEnumerable<Data> GetData();
    }
}