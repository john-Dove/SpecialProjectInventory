namespace SpecialProjectInventory
{
    public static class RoleHelper
    {
        public static bool IsAdmin()
        {
            return MainForm.UserRole == "Admin";
        }

        public static bool IsManager()
        {
            return MainForm.UserRole == "Manager";
        }

        public static bool IsEmployee()
        {
            return MainForm.UserRole == "Employee";
        }
    }
}
