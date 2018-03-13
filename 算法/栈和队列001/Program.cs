using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栈和队列001
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>()
            {
                1,
                4,
                7,
                23,
                56,
                897,
                3,
                2,
                12,
                53,
                99
            };
           
            Print(BubbleSort(list));
            Console.WriteLine("");
            Print(BubbleSortDesc(list));
        }
         

        static List<int> BubbleSort(List<int> list)
        {
            int temp;
            for (int i = 0; i < list.Count-1; i++)
            {
                for (int j = 0; j < list.Count - 1-i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
           
            return list;
        }

        static List<int> BubbleSortDesc(List<int> list)
        {
            int temp;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }

        static void Print(List<int> list)
        {
            foreach (var i in list)
            {
                 Console.Write(i+" ");
            }
        }
    }

}
