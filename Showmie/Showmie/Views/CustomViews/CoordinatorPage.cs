using Showmie.Models;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    public class CoordinatorPage : Grid
    {
        public event EventHandler ShowFilters;

        public void ShowFiltersAction()
        {
            ShowFilters?.Invoke(this, EventArgs.Empty);
        }

        public CoordinatorPage()
        {

        }

    }
}
