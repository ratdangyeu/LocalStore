namespace LocalStore.WebApp.Resources
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
        public static string DeleteConfirm = "Bạn có chắc chắn muốn xóa?";
        public static string NoDataContent = "Không có dữ liệu bản ghi";
        public static string LoadMessage = "Vui lòng chờ ...";
        public static string YesButtonContent = "Đồng ý";
        public static string LoginFailed = "Email hoặc mật khẩu chưa chính xác";
        #endregion

        #region WareHouseValidators
        public static string WareHouseNameRequired = "Tên kho không được để trống";
        public static string WareHouseNameLength = "Tên kho không vượt quá {0} ký tự";
        #endregion

        #region UserValidators
        public static string UserFirstNameRequired = "Tên không được để trống";
        public static string UserFirstNameLength = "Tên không vượt quá {0} ký tự";
        public static string UserLastNameLength = "Họ không vượt quá {0} ký tự";
        public static string UserEmailRequired = "Tên đăng nhập không được để trống";
        public static string UserEmailFormat= "Email không đúng định dạng";
        public static string UserPasswordLength = "Mật khẩu không vượt quá {0} ký tự";
        #endregion

        #region RoleValidators

        #endregion

        #region CommonValidators
        public static string CommonAddressLength = "Địa chỉ không vượt quá {0} ký tự";
        public static string CommonDescriptionLength = "Mô tả không vượt quá {0} ký tự";
        #endregion

        #region WareHouseFields
        public static string WareHouseFieldsCode = "Mã kho";
        public static string WareHouseFieldsName = "Tên kho";
        #endregion

        #region CommonFields
        public static string CommonFieldsAddress = "Địa chỉ";
        public static string CommonFieldsDescription = "Mô tả";
        public static string CommonFieldsInactive = "Ngừng kích hoạt";
        #endregion
    }
}