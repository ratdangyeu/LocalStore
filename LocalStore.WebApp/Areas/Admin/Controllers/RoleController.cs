using AutoMapper;
using FluentValidation;
using LocalStore.Service;
using LocalStore.WebApp.Models;
using System.Web.Mvc;

namespace LocalStore.WebApp.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        #region Fields
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IValidator<RoleModel> _validator; 
        #endregion

        #region Ctor
        public RoleController(
            IRoleService roleService,
            IMapper mapper,
            IValidatorFactory validatorFactory)
        {
            _roleService = roleService;
            _mapper = mapper;
            _validator = validatorFactory.GetValidator<RoleModel>();
        }
        #endregion

        #region Methods
        // GET: Admin/Role
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Utilities

        #endregion
    }
}