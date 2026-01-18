using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RivenSDK.Core
{
    public class RivenFS
    {
        public static void CheckDirectory(string dir) 
        {
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir); 
        }
    }
}
