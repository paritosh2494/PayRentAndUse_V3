﻿using System.Web;
using System.Web.Mvc;

namespace PayRentAndUse_V3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
