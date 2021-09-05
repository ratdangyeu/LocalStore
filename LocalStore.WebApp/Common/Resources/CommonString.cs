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
        public static string RetypePasswordInvalid = "Mật khẩu không trùng khớp";
        public static string ExistEmail = "Địa chỉ email đã tồn tại";
        #endregion

        #region Titles
        public static string CommonSignIn = "Đăng nhập";
        public static string CommonSignOut = "Đăng xuất";
        public static string CommonRegister = "Đăng ký";
        public static string CommonWareHouse = "Kho vận";
        public static string CommonWareHouseItem = "Vật tư";
        public static string CommonWareHouseItemCategory = "Loại vật tư";
        public static string CommonHome = "Trang chủ";
        public static string CommonBeginningWareHouse = "Tồn kho đầu kỳ";
        public static string CommonWareHouseBook = "Sổ kho";
        public static string CommonVendor = "Nhà cung cấp";
        public static string CommonUnit = "Đơn vị";
        public static string CommonWareHouseItemUnit = "Đơn vị chuyển đổi";
        #endregion

        #region WareHouseValidators
        public static string WareHouseNameRequired = "Tên kho không được để trống";
        public static string WareHouseNameLength = "Tên kho không vượt quá {0} ký tự";
        #endregion

        #region UserValidators
        public static string UserFirstNameRequired = "Tên không được để trống";
        public static string UserFirstNameLength = "Tên không vượt quá {0} ký tự";
        public static string UserLastNameLength = "Họ không vượt quá {0} ký tự";
        public static string UserEmailRequired = "Email không được để trống";
        public static string UserEmailFormat= "Email không đúng định dạng";
        public static string UserPasswordLength = "Mật khẩu không vượt quá {0} ký tự";
        public static string UserPasswordRequired = "Mật khẩu không được để trống";
        #endregion

        #region RoleValidators
        public static string RoleNameRequired = "Tên quyền không được để trống";
        public static string RoleNameLength = "Tên quyền không vượt quá {0} ký tự";
        #endregion

        #region StoreValidators
        public static string StoreNameRequired = "Tên cửa hàng không được để trống";
        public static string StoreNameLength = "Tên cửa hàng không vượt quá {0} ký tự";
        #endregion

        #region CommonValidators
        public static string CommonAddressLength = "Địa chỉ không vượt quá {0} ký tự";
        public static string CommonDescriptionLength = "Mô tả không vượt quá {0} ký tự";
        #endregion

        #region WareHouseFields
        public static string WareHouseFieldsCode = "Mã kho";
        public static string WareHouseFieldsName = "Tên kho";
        #endregion

        #region UserFields
        public static string UserFieldsCode = "Mã người dùng";
        public static string UserFieldsFirstName = "Tên người dùng";
        public static string UserFieldsLastName = "Họ";
        public static string UserFieldsPassword = "Mật khẩu";
        #endregion

        #region RoleFields
        public static string RoleFieldsCode = "Mã quyền";
        public static string RoleFieldsName = "Tên quyền";
        #endregion

        #region CommonFields
        public static string CommonFieldsAddress = "Địa chỉ";
        public static string CommonFieldsDescription = "Mô tả";
        public static string CommonFieldsInactive = "Ngừng kích hoạt";
        public static string CommonFieldsEmail = "Hòm thư";
        public static string CommonFieldsCreatedDate = "Ngày tạo";
        public static string CommonFieldsModifiedDate = "Ngày chỉnh sửa";
        #endregion
    }
}