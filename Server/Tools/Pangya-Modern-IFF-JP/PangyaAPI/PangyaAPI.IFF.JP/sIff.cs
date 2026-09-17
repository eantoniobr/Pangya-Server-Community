using PangyaAPI.IFF.JP.Extensions;
using System;
using System.ComponentModel;
namespace PangyaAPI.IFF.JP.Models
{ 
    public class sIff 
    {
       private static IFFHandle Instance { get; set; }

        public static IFFHandle getInstance()
        {
            try
            {
                if (Instance == null)
                    Instance = new IFFHandle();

                return Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
