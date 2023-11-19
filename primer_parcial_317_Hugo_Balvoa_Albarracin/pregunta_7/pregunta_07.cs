using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace pregunta_7_pi_con_net
{
    class Program
    {
        static int lim = 2000;
        static double dig = 0;

        static int i = 0;

        static void generar_dig_pi(Object dd)
        {
            int j;
            while ((j = Interlocked.Increment(ref i) - 1) < lim)
            {//

                ///Problema de Basilea, resuelto por Euler en 1735
                dig = dig + (double)(1 / (double)((j + 1) * (j + 1)));
            }
        }

        static void Main(string[] args)
        {
            for (int a = 0; a < 4; a++)
            {
                ThreadPool.QueueUserWorkItem(generar_dig_pi);
            }
            while (i < lim)
            {
                Thread.Sleep(100);
            }

            dig = dig * 6;
            dig = Math.Sqrt(dig);

            Console.Write(dig);

            Console.ReadKey();

        }
    }
}
