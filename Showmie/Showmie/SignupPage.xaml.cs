using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Showmie
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private int pageNum;

        public int PageNum {
            get { return pageNum; }
            set { pageNum = value; }
        }

    }
}
