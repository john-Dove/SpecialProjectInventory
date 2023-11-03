using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public static class ProjectUtility
    {
        public static MaskedTextBox CreatePhoneNumberMaskedTextBox()
        {
            MaskedTextBox phoneMaskedTextBox = new MaskedTextBox();
            phoneMaskedTextBox.Mask = "(999) 000-0000";
            phoneMaskedTextBox.PromptChar = '_';
            phoneMaskedTextBox.ValidatingType = typeof(string);
            return phoneMaskedTextBox;
        }
    }
}
