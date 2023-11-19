using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static int lim=10000;
        static int[] lista=new int[lim];
        static int i=0;

        static void core(Object dd) {

            int j;
            int ss;
//interlock  ref 
            while ((j = Interlocked.Increment(ref i) - 1) < lim)
            {
                if (j % 2 == 0)
                {
                    ss = (j / 2) + 1;
                    ss = ss * ss;
                    lista[j] = ss + 1;
                }
                else {
                    lista[j] = j + 1;
                }

            }
        }

        static void Main(string[] args)
        {
            for (int a=0; a < 4; a++)
            {
                ThreadPool.QueueUserWorkItem(core);
            }
            while(i<lim){
                Thread.Sleep(100); //se da ese tiempo hasta qeue los hilos terminen 
            }

            foreach(int val in lista){
                Console.Write(val+" ");

            }
            Console.ReadKey();
        }



    }
}
