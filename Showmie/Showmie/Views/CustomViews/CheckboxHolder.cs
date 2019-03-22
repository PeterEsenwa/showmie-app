using System.ComponentModel;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    internal class CheckboxHolder : StackLayout
    {
        internal void _customCheckbox_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CustomCheckbox customChecbox = sender as CustomCheckbox;
            if (e.PropertyName == "IsChecked" && customChecbox.IsChecked == true)
            {
                int currentIndex = Children.IndexOf(customChecbox);
                foreach (CustomCheckbox checkbox in Children)
                {
                    int otherIndex = Children.IndexOf(checkbox);
                    if (otherIndex != currentIndex)
                    {
                        checkbox.IsChecked = false;
                    }
                }
            }
        }
    }
}
