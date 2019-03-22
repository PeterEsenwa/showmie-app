using System;
using System.Collections.Generic;
using System.Text;

namespace Showmie.Utils
{
    class URLS
    {
        //public static string RestUrl = "192.168.43.173/api/todoitems/{0}";http://www.showmie.com/api/user/?email-username=testr_1&password=1234
        //public static string LoginUser = "http://172.18.85.49/showmie/api/user/?email-username={0}&password={1}";
        public static string LoginUser = "http://www.showmie.com/api/user/?email-username={0}&password={1}";
        public static string SignupUser = "http://www.showmie.com/api/user/";
        //public static string GetUserByID = "http://172.18.85.49/showmie/api/user/?userID={0}";
        public static string GetUserByID = "http://www.showmie.com/api/user/?userID={0}";
        //public static string GetDesignsByCategory = "http://172.18.85.49/showmie/api/designs.php?category={0}";
        public static string GetDesignsByCategory = "http://www.showmie.com/api/designs.php?category={0}";
        //public static string GetDesignByID = "http://172.18.85.49/showmie/api/designs.php?designID={0}";
        public static string GetDesignByID = "http://www.showmie.com/api/designs.php?designID={0}";
        public static string devGetDesignByID = "http://172.18.85.49/showmie/api/designs.php?designID={0}";
        public static string GetUserNotificationsByID = "http://www.showmie.com/api/notifications.php?userId={0}&isRead={1}";
        public static string UserOperations = "http://www.showmie.com/api/user/";
    }
}
