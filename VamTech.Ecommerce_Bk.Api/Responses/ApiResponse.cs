﻿using VamTech.Ecommerce.Core.CustomEntities;

namespace VamTech.Ecommerce.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadata Meta { get; set; }
    }
}
