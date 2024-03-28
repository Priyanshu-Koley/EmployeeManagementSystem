public static class EmployeeManagementPermissions
{
    public const string GroupName = "EmployeeManagement";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class HR
    {
        public const string Default = GroupName + ".HR";
        public const string CreateEmployee = Default + ".CreateEmployee";
        public const string EditEmployee = Default + ".EditEmployee";
        public const string DeleteEmployee = Default + ".DeleteEmployee";
        public const string ViewEmployee = Default + ".ViewEmployee";
    }

    public static class Admin
    {
        public const string Default = GroupName + ".Admin";
        public const string CreateHR = Default + ".CreateHR";
    }
}
