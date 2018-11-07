﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFTesterIF
{
    public enum DatabaseType
    {
        SqlServer,
        Sqlite,
        TextFiles
    }

    public enum TesterIFType
    {
        NIGPIB,
        RS232,
        TTL
    }

    public enum TesterIFProtocol
    {
        MTGPIB,
        RSGPIB,
        RSRS232,
        TTL
    }

    public enum UserAccessGroup
    {
        Admin,
        Maint,
        Operator
    }

    public enum TestHandlingMode
    {
        Synchronous,
        Asynchronous,
        Serial,
        Single
    }
}