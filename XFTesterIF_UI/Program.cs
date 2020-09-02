using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFTesterIF;

namespace XFTesterIF_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////Initialize Tester IF setting
            //switch (UserSettings.Default.TesterIFType)
            //{
            //    case "NIGPIB":
            //        if (UserSettings.Default.TesterIFProtocol == "MTGPIB")
            //            GlobalIF.InitializeIFConnections(TesterIFType.NIGPIB, TesterIFProtocol.MTGPIB);
            //        if (UserSettings.Default.TesterIFProtocol == "RSGPIB")
            //            GlobalIF.InitializeIFConnections(TesterIFType.NIGPIB, TesterIFProtocol.RSGPIB);
            //        break;

            //    case "RS232":
            //        GlobalIF.InitializeIFConnections(TesterIFType.RS232, TesterIFProtocol.RSRS232);
            //        break;

            //    case "TTL":
            //        break;

            //    default:
            //        break;
            //}

            Application.Run(new TesterIFMain());
        }
    }
}
