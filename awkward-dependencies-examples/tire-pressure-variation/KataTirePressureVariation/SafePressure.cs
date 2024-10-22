using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataTirePressureVariation
{
    public class SafePressure
    {
        public SafePressure(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get;  }
        public int Max { get;  }
    }
}
