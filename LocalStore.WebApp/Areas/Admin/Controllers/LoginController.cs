using AutoMapper;
using FluentValidation;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Models;
using LocalStore.WebApp.Resources;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace LocalStore.WebApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<UserModel> _validator;
        #endregion

        #region Ctor
        public LoginController(
            IUserService userService,
            IMapper mapper,
            IValidatorFactory validatorFactory)
        {
            _userService = userService;
            _mapper = mapper;
            _validator = validatorFactory.GetValidator<UserModel>();
        }
        #endregion

        #region Methods
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        // Xử lý đăng nhập
        [ValidateAntiForgeryToken]
        public string Login(UserModel user)
        {
            var entity = _mapper.Map<UserModel, User>(user);
            var checkLogin = _userService.LoginAsync(entity);

            if (checkLogin)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = true
                });
            }
            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Success = false,
                Message = CommonString.LoginFailed
            });
        }

        public ActionResult Register()
        {
            return View();
        }
        #endregion
    }
}