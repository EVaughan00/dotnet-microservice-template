﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.API.Commands;
using Template.API.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Template.API.Initializers
{

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<JwtGenerator>();

        }
    }
}
