using LocalStore.Domain;
using PagedList;
using System.Collections.Generic;

namespace LocalStore.Service
{
    public interface IRoleService
    {
        void InsertAsync(Role entity);

        void UpdateAsync(Role entity);

        void DeleteAsync(IEnumerable<string> ids);

        bool ExistAsync(string code);

        void ActivationAsync(IEnumerable<string> ids, bool status);

        Role GetByIdAsync(string id);

        IEnumerable<Role> GetAll(bool showHidden = false);

        IPagedList<Role> Get(RoleSearchContext ctx);
    }
}
