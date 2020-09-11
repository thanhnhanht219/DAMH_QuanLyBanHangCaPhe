using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ConvertValue
    {

        public static string convertValueMoney(double giathucte)
        {
            string gia = giathucte.ToString();
            string giamoi = "";
            int count = 0;
            for (int i = gia.Length - 1; i >= 0; i--)
            {
                if (count == 3)
                {
                    giamoi = String.Concat(",", giamoi);
                    count = 0;
                }
                giamoi = String.Concat(gia[i], giamoi);
                count++;
            }
            return giamoi;

        }
    }
}
