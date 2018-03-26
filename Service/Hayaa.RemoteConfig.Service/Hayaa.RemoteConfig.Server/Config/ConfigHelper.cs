﻿using Hayaa.ConfigSeed.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.RemoteService.Core.Config
{
    internal class ConfigHelper: ConfigTool<RemoteServiceConfig>
    {
        private static ConfigHelper _instance = new ConfigHelper();
        private ConfigHelper() : base(DefineTable.RemoteServiceComponetID)
        {

        }

        internal static ConfigHelper Instance { get => _instance; }
    }
}
