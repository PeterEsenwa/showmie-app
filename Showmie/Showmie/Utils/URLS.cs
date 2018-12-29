using System;
using System.Collections.Generic;
using System.Text;

namespace Showmie.Utils
{
    class URLS
    {
        //public static string RestUrl = "192.168.43.173/api/todoitems/{0}";http://www.showmie.com/api/user/?email-username=testr_1&password=1234
        public static string GetUserInfo = "http://www.showmie.com/api/user/?email-username={0}&password={1}";
        public static string GetDesignsByCategory = "http://www.showmie.com/api/designs.php?category={0}";
    }
}
