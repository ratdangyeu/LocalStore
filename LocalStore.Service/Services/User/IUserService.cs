using LocalStore.Domain;
using PagedList;
using System.Collections.Generic;

namespace LocalStore.Service
{
    public interface IUserService
    {
        void InsertAsync(User entity);

        void UpdateAsync(User entity);

        void DeleteAsync(IEnumerable<string> ids);

        bool ExistAsync(string code);

        bool ExistAsyncEmail(string email);

        bool LoginAsync(User entity);

        void ActivationAsync(IEnumerable<string> ids, bool status);

        User GetByIdAsync(string id);

        IEnumerable<User> GetAll(bool showHidden = false);

        IPagedList<User> Get(UserSearchContext ctx);
    }
}
