using System.Collections.Generic;
using System.Web.Mvc;

namespace LocalStore.WebApp.Models
{
    public class UserRoleModel : BaseModel
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public List<SelectListItem> AvailableUsers { get; set; }

        public List<SelectListItem> AvailableRoles { get; set; }

        public UserRoleModel()
        {
            AvailableUsers = new List<SelectListItem>();

            AvailableRoles = new List<SelectListItem>();
        }
    }
}