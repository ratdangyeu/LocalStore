using AutoMapper;
using LocalStore.Domain;
using LocalStore.Service;
using LocalStore.WebApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace LocalStore.WebApp.Controllers
{
    public class WareHouseController : Controller
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IWareHouseService _warehouseService;
        #endregion

        #region Ctor
        public WareHouseController(
            IMapper mapper,
            IWareHouseService warehouseService)
        {
            _mapper = mapper;
            _warehouseService = warehouseService;
        }
        #endregion

        #region Methods
        // GET: WareHouse
        public ActionResult Index()
        {
            return View();
        }

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

        public string InsertData(WareHouseModel model)
        {
            if (model == null || _warehouseService.ExistAsync(model.Code))
            {
                return CommonString.InsertFailed;
            }
            else
            {
                var entity = _mapper.Map<WareHouseModel, Warehouse>(model);
                _warehouseService.InsertAsync(entity);
                return CommonString.InsertSuccess;
            }            
        }
        #endregion

        #region Utilities
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
        #endregion
    }
}