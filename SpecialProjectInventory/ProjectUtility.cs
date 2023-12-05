using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace SpecialProjectInventory
{
    public static class ProjectUtility
    {
        public static MaskedTextBox CreatePhoneNumberMaskedTextBox()
        {
            MaskedTextBox phoneMaskedTextBox = new MaskedTextBox
            {
                Mask = "(999) 000-0000",
                PromptChar = '_',
                ValidatingType = typeof(string)
            };
            return phoneMaskedTextBox;
        }
        public static bool IsPasswordComplex(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(char.IsUpper)) return false;
            if (!password.Any(char.IsLower)) return false;
            if (!password.Any(char.IsDigit)) return false;
            if (!password.Any(ch => !char.IsLetterOrDigit(ch))) return false; // Checks for a special character

            return true;
        }


        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // This is a computeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converts byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
               


    }
}
