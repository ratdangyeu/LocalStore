using AutoMapper;
using FluentValidation;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Common.Helper;
using LocalStore.WebApp.Models;
using LocalStore.WebApp.Resources;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace LocalStore.WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IValidator<UserModel> _validator;
        #endregion

        #region Ctor
        public UserController(
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
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        // Load dữ liệu jsGrid
        public string LoadData()
        {
            var searchModel = GetFilter();
            UserSearchContext searchContext = _mapper.Map<UserSearchModel, UserSearchContext>(searchModel);

            var entities = _userService.Get(searchContext);
            var models = new List<UserModel>();

            if (entities?.Count > 0)
            {
                foreach(var e in entities)
                {
                    var m = _mapper.Map<User, UserModel>(e);
                    m.CreatedDate = e.CreatedDate.ToLocalTime();
                    m.ModifiedDate = e.ModifiedDate.ToLocalTime();
                    m.StrCreatedDate = m.CreatedDate.ToString("dd/MM/yyyy hh:mm tt");
                    m.StrModifiedDate = m.ModifiedDate.ToString("dd/MM/yyyy hh:mm tt");
                    models.Add(m);
                }
            }

            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Data = models,
                ItemsCount = entities.TotalItemCount
            });
        }

        [ValidateAntiForgeryToken]
        public string InsertData(UserModel model)
        {
            var validateResult = _validator.Validate(model);
            if (!validateResult.IsValid)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = HelperClass.ErrorMessageValidate(validateResult)
                });
            }

            if (model == null)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.InsertFailed
                });
            }

            if (_userService.ExistAsyncEmail(model.Email))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.ExistEmail
                });
            }

            var entity = _mapper.Map<UserModel, User>(model);
            _userService.InsertAsync(entity);

            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Success = true,
                Message = CommonString.InsertSuccess
            });
        }

        [ValidateAntiForgeryToken]
        public string UpdateData(string id, UserModel model)
        {
            var validateResult = _validator.Validate(model);
            if (!validateResult.IsValid)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = HelperClass.ErrorMessageValidate(validateResult)
                });
            }

            if (string.IsNullOrEmpty(id) || model == null || !_userService.ExistAsync(model.Code))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.UpdateFailed
                });
            }

            var entity = _mapper.Map<UserModel, User>(model);
            _userService.UpdateAsync(entity);

            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Success = true,
                Message = CommonString.UpdateSuccess
            });
        }

        [ValidateAntiForgeryToken]
        public string DeleteData(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.DeleteFailed
                });
            }

            _userService.DeleteAsync(new List<string> { id });
            return JsonConvert.SerializeObject(new BaseResult<object>
            {
                Success = true,
                Message = CommonString.DeleteSuccess
            });
        }
        #endregion

        #region Utilities
        // Lấy dữ liệu lọc 
        private UserSearchModel GetFilter()
        {
            NameValueCollection filter = HttpUtility.ParseQueryString(Request.Url.Query);
            int.TryParse(filter["PageIndex"], out int pageNumber);
            int.TryParse(filter["PageSize"], out int pageSize);

            return new UserSearchModel
            {
                Code = filter["Code"],
                Email = filter["Email"],
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        #endregion

    }
}