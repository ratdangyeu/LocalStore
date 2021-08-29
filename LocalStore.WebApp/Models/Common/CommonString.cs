namespace LocalStore.WebApp.Models
{
    public static class CommonString
    {
        #region Notifies
        public static string InsertSuccess = "Thêm mới thành công";
        public static string UpdateSuccess = "Cập nhật thành công";
        public static string DeleteSuccess = "Xóa thành công";
        public static string InsertFailed = "Thêm mới thất bại";
        public static string UpdateFailed = "Cập nhật không thành công";
        public static string DeleteFailed = "Xóa không thành công";
        #endregion

        #region WareHouseValidator
        public static string WareHouseCodeRequired = "Mã kho không được để trống";
        public static string WareHouseCodeLength = $"Mã kho không vượt quá {0} ký tự";
        public static string WareHouseNameRequired = "Tên kho không được để trống";
        public static string WareHouseNameLength = $"Tên kho không vượt quá {0} ký tự";
        public static string WareHouseAddressLength = $"Địa chỉ không vượt quá {0} ký tự";
        public static string WareHouseDescriptionLength = $"Mô tả không vượt quá {0} ký tự";
        #endregion
    }
}