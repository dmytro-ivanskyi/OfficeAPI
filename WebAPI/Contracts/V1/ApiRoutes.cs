﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root+"/"+Version;

        public static class Offices
        {
            public const string GetAll = Base+"/offices";
            public const string Get = Base + "/office/{officeId}";
            public const string Create = Base + "/office";
            public const string Update = Base + "/office/{officeId}";
            public const string Delete = Base + "/office/{officeId}";
        }
    }
}
