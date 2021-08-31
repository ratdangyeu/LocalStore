using AutoMapper;
using FluentValidation;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LocalStore.WebApp.Controllers
{
    public class WareHouseController : Controller
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IWareHouseService _warehouseService;
        private readonly IValidator<WareHouseModel> _validator;
        #endregion

        #region Ctor
        public WareHouseController(
            IMapper mapper,
            IWareHouseService warehouseService,
            IValidatorFactory validatorFactory)
        {
            _mapper = mapper;
            _warehouseService = warehouseService;
            _validator = validatorFactory.GetValidator<WareHouseModel>();
        }
        #endregion

        #region Methods
        // GET: WareHouse
        public ActionResult Index()
        {
            return View();
        }

        // Load dữ liệu có phân trang
        public string LoadData()
        {
            WareHouseSearchModel searchModel = GetFilter();
            var searchContext = _mapper.Map<WareHouseSearchModel, WareHouseSearchContext>(searchModel);

            var entities = _warehouseService.Get(searchContext);
            var models = new List<WareHouseModel>();

            if (entities?.Count > 0)
            {
                foreach(var e in entities)
                {
                    var m = _mapper.Map<Warehouse, WareHouseModel>(e);
                    models.Add(m);
                }
            }

            return JsonConvert.SerializeObject(new BaseResult<List<WareHouseModel>> { 
                Data = models,
                ItemsCount = entities.TotalItemCount
            });
        }

        // Thêm mới dữ liệu
        public string InsertData(WareHouseModel model)
        {            
            var validatorResult = _validator.Validate(model);
            if (!validatorResult.IsValid)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = ErrorMessageValidate(validatorResult)
                });
            }

            if (model == null || _warehouseService.ExistAsync(model.Code))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.InsertFailed
                });
            }
            else
            {
                var entity = _mapper.Map<WareHouseModel, Warehouse>(model);
                entity.Code = model.Code;
                _warehouseService.InsertAsync(entity);
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = true,
                    Message = CommonString.InsertSuccess
                });
            }            
        }

        // Chỉnh sửa dữ liệu
        public string UpdateData(string id, WareHouseModel model)
        {
            var validatorResult = _validator.Validate(model);
            if (!validatorResult.IsValid)
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = ErrorMessageValidate(validatorResult)
                });
            }

            if (string.IsNullOrEmpty(id) || model == null || !_warehouseService.ExistAsync(model.Code))
            {
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = false,
                    Message = CommonString.UpdateFailed
                });
            }
            else
            {
                var entity = _mapper.Map<WareHouseModel, Warehouse>(model);
                _warehouseService.UpdateAsync(entity);
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = true,
                    Message = CommonString.UpdateSuccess
                });
            }
        }

        // Xóa dữ liệu
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
            else
            {
                _warehouseService.DeleteAsync(new List<string> { id});
                return JsonConvert.SerializeObject(new BaseResult<object>
                {
                    Success = true,
                    Message = CommonString.DeleteSuccess
                });
            }
        }
        #endregion

        #region Utilities
        // Lấy dữ liệu lọc từ jsgrid
        private WareHouseSearchModel GetFilter()
        {
            NameValueCollection filter = HttpUtility.ParseQueryString(Request.Url.Query);
            int.TryParse(filter["PageIndex"], out int pageNumber);
            int.TryParse(filter["PageSize"], out int pageSize);

            return new WareHouseSearchModel
            {
                Code = filter["Code"],
                Name = filter["Name"],
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        // Xuất lỗi validate
        private string ErrorMessageValidate(FluentValidation.Results.ValidationResult validatorResult)
        {
            StringBuilder errors = new StringBuilder();
            validatorResult.Errors.ForEach(e =>
            {
                errors.Append(e.ErrorMessage);
                errors.Append("<br>");
            });
            return errors.ToString();
        }
        #endregion
    }
}