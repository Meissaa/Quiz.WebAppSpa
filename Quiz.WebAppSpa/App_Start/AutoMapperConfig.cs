﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.WebAppSpa.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<>();
                //cfg.CreateMap<>();
            });
        }
    }
}