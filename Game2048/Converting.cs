using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal static class Converting
    {
        public static int ToInt(char cNumber)
        {
            if(cNumber < '0' || cNumber > '9')
                return 0;
            else if (cNumber ==  '0')
                return 0;
            else if (cNumber ==  '1')
                return 1;
            else if (cNumber ==  '2')
                return 2;
            else if (cNumber ==  '3')
                return 3;
            else if (cNumber ==  '4')
                return 4;
            else if (cNumber ==  '5')
                return 5;
            else if (cNumber ==  '6')
                return 6;
            else if (cNumber ==  '7')
                return 7;
            else if (cNumber ==  '8')
                return 8;
            return 9;
        }
        public static int ToInt(string sNumber)
        {
            for (int i = 0; i < sNumber.Length; i++)
                if (sNumber[i] < '0' || sNumber[i] > '9')
                {
                    sNumber = sNumber.Remove(i);
                }
            int result = 0;
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < sNumber.Length; i++)
                queue.Enqueue(ToInt(sNumber[i]));
            while (queue.Count > 0)
                result = result * 10 + queue.Dequeue();
            return result;
        }
    }
}
