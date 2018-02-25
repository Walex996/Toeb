﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Toeb.DataAccess.EF;
using Toeb.Model.ViewModels;

namespace Toeb.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                StateMap(cfg);
                UserMap(cfg);
            });
        }

        private static void StateMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<State, StateModel>();
            cfg.CreateMap<StateModel, State>();
            cfg.CreateMap<StateItem, State>();
            cfg.CreateMap<State, StateItem>();
        }
        private static void UserMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserModel>();
            cfg.CreateMap<UserModel, User>();
            cfg.CreateMap<UserItem, User>();
            cfg.CreateMap<User, UserItem>();
        }
    }
}