using AutoMapper;
using FluentValidation;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Common.Helper;
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
            var user = new UserModel();
            return View(user);
        }

        // Xử lý đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Login(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.LoginFailed
                });
            }
            else
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
                else
                {
                    return JsonConvert.SerializeObject(new BaseResult<object>
                    {
                        Success = false,
                        Message = CommonString.LoginFailed
                    });
                }
            }                       
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Register(UserModel user)
        {
            var validateResult = _validator.Validate(user);

            if (!validateResult.IsValid)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = HelperClass.ErrorMessageValidate(validateResult)
                });
            }

            if (_userService.ExistAsyncEmail(user.Email))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.ExistEmail
                });
            }

            if (user.Password != user.RetypePassword)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.RetypePasswordInvalid
                });
            }

            var entity = _mapper.Map<UserModel, User>(user);
            _userService.InsertAsync(entity);
            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Success = true
            });
        }

        
        #endregion

        #region Utilities

        #endregion
    }
}