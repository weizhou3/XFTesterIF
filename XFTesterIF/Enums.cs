using System;
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
        MTGPIB8,
        MTGPIB4,
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
    public enum PlcDataType
    {
        TypeBool,
        TypeUshort,
        TypeUint,
        Unassigned
    }

    public enum PlcMemArea
    {
        CIO,
        WR,
        WR_bit,
        HR,
        HR_bit,
        AR,
        DM
    }
}
