﻿using System;

namespace Service.Abstraction.ResponseModels
{
    public class PermissionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
