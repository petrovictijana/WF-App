﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Server.FactoryPattern
{
    public interface IDbConnectionFactory
    {
        DbConnection createConnection(string connectionString);
    }
}
