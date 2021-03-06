﻿//
// Copyright 2015 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//


using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace SteelToe.CloudFoundry.Connector.MySql
{
    public class MySqlProviderConfiguration : AbstractServiceConfiguration
    {
        public const string Default_Server = "localhost";
        public const int Default_Port = 3306;
        private const string MYSQL_CLIENT_SECTION_PREFIX = "mysql:client";

        public MySqlProviderConfiguration()
        {
        }

        public MySqlProviderConfiguration(IConfiguration config) :
            base()
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            var section = config.GetSection(MYSQL_CLIENT_SECTION_PREFIX);
            section.Bind(this);
        }

        public string ConnectionString { get; set; }
        public string Server { get; set; } = Default_Server;
        public int Port { get; set; } = Default_Port;
        public string Username { get; set; }
        public string Password { get; set;  }
        public string Database { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(ConnectionString)) {
                return ConnectionString;
            }

            StringBuilder sb = new StringBuilder();
            AddKeyValue(sb, nameof(Server), Server);
            AddKeyValue(sb, nameof(Port), Port);
            AddKeyValue(sb, nameof(Username), Username);
            AddKeyValue(sb, nameof(Password), Password);
            AddKeyValue(sb, nameof(Database), Database);
            return sb.ToString();
        }

    }
}
