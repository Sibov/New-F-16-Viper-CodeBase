using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace AircraftSwap
{
    class F16Debug
    {
       static bool enabled = false;
       public static void Log(string s)
        {
            if(enabled)
            Debug.Log(s);
        }
    }
}
