using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    public static class Utility
    {
        private static Random m_random = new Random();

        public static int Random()
        {
            return m_random.Next();
        }

        public static int Random(int maxValue)
        {
            return m_random.Next(maxValue);
        }

        public static int Random(int minValue, int maxValue)
        {
            return m_random.Next(minValue, maxValue);
        }
        public static bool Matches(this Array arr1, Array arr2)
        {
            if (arr1.GetType() != arr2.GetType() || arr1.Length != arr2.Length)
                return false;
            for (int index = 0; index < arr1.Length; ++index)
            {
                if (!arr1.GetValue(index).Equals(arr2.GetValue(index)))
                    return false;
            }
            return true;
        }
    }
}
