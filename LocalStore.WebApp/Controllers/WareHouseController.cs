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

            return JsonConvert.SerializeObject(models);
        }

        public void InsertData(WareHouseModel model)
        {
            if (model == null)
            {

            }

            var entity = _mapper.Map<WareHouseModel, Warehouse>(model);
            _warehouseService.InsertAsync(entity);
        }
        #endregion

        #region Utilities
        private WareHouseSearchModel GetFilter()
        {
            NameValueCollection filter = HttpUtility.ParseQueryString(Request.Url.Query);

            return new WareHouseSearchModel
            {
                Code = filter["Code"],
                Name = filter["Name"],
                PageNumber = 1,
                PageSize = 20
            };
        }
        #endregion
    }
}