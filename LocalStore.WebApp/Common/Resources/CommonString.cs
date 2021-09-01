namespace LocalStore.WebApp.Resources
{
    public static class CommonString
    {
        #region CommonNotifies
        public static string InsertSuccess = "Thêm mới thành công";
        public static string UpdateSuccess = "Cập nhật thành công";
        public static string DeleteSuccess = "Xóa thành công";
        public static string InsertFailed = "Thêm mới thất bại";
        public static string UpdateFailed = "Cập nhật không thành công";
        public static string DeleteFailed = "Xóa không thành công";
        public static string DeleteConfirm = "Bạn có chắc chắn muốn xóa?";
        public static string NoDataContent = "Không có dữ liệu bản ghi";
        public static string LoadMessage = "Vui lòng chờ ...";
        public static string YesButtonContent = "Đồng ý";
        #endregion

        #region WareHouseValidators
        public static string WareHouseCodeRequired = "Mã kho không được để trống";
        public static string WareHouseCodeLength = "Mã kho không vượt quá {0} ký tự";
        public static string WareHouseNameRequired = "Tên kho không được để trống";
        public static string WareHouseNameLength = "Tên kho không vượt quá {0} ký tự";
        #endregion

        #region CommonValidators
        public static string CommonAddressLength = "Địa chỉ không vượt quá {0} ký tự";
        public static string CommonDescriptionLength = "Mô tả không vượt quá {0} ký tự";
        #endregion
    }
}