using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Server
{
    public static class Utility
    {
        private static Random m_random = new Random();

        public static int Random()
        {
            return Utility.m_random.Next();
        }

        public static int Random(int maxValue)
        {
            return Utility.m_random.Next(maxValue);
        }

        public static int Random(int minValue, int maxValue)
        {
            return Utility.m_random.Next(minValue, maxValue);
        }
    }
}
