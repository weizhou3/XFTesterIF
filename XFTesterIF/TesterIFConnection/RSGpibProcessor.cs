using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFTesterIF.Models;

namespace XFTesterIF.TesterIFConnection
{
    public class RSGpibProcessor
    {
        private string SetSRQ(GpibCommDataModel GpibData)//Set SRQ and Spbyte
        {
            string spbyte;
            int[] Spbyte = new int[8];
            //set SPByte per SOT
            Spbyte[1] = 1;//enable SRQ @ bit6
            Spbyte[0] = 0;
            for (int i = 0; i < 4; i++)//set SOT CS1-CS4 @ bit0..3
            {
                Spbyte[7 - i] = GpibData.SOT[i];
            }

            //convert spbyte array to hex string
            string[] array1 = Array.ConvertAll(Spbyte, element => element.ToString());
            spbyte = string.Join("", array1);
            spbyte = GlobalIF.HexConvert2(spbyte);
            return spbyte;
        }

    }
}
