﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Veronica.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}