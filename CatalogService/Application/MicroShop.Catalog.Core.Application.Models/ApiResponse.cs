﻿namespace MicroShop.Catalog.Core.Application.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Response { get; set; }
    }
}