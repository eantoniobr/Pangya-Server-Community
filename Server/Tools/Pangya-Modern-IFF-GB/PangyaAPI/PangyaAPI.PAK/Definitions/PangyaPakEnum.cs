using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.PAK.Definitions
{
    public enum PangyaPakEnum
    {
        GB=0,
        JP,
        TH,
        EU,
        ID,
        KR,
        PakOld,
        PakUnknown = -1,
        PakNoSelected =-2,
        Universal = 10

    }

    public enum PakResultEnum 
    { 
    Sucess,
    Falied,
    Signature_Invalid, 
    New_Test
    }
}
