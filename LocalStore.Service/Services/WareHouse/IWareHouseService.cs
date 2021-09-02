using LocalStore.Domain;
using PagedList;
using System.Collections.Generic;

namespace LocalStore.Service
{
    public interface IWareHouseService
    {
        void InsertAsync(Warehouse entity);

        void UpdateAsync(Warehouse entity);

        void DeleteAsync(IEnumerable<string> ids);

        bool ExistAsync(string code);

        void ActivationAsync(IEnumerable<string> ids, bool status);

        Warehouse GetByIdAsync(string id);

        IEnumerable<Warehouse> GetAll(bool showHidden = false);

        IPagedList<Warehouse> Get(WareHouseSearchContext ctx);
    }
}
