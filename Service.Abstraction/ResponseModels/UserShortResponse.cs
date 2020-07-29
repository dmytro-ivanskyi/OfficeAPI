﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstraction.ResponseModels
{
    public class UserShortResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
