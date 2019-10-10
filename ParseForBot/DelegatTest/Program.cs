using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseForBot.DelegatTest
{

    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { -1, -3, -4, 5, -7, 9, 0, -2 };

            Console.WriteLine("Result before method");
            foreach(var b in arr)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine("Result after method");
            NegativeMethod(ref arr);

            A ac = new C();
            Console.WriteLine(ac.Print());
        }

        public static void NegativeMethod(ref int[] arr)
        {
            int[] newArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0 && arr[i] % 3 != 0)
                {
                    newArr[i] = arr[i] * -1;
                }
                else
                {
                    newArr[i] = arr[i];
                }
                Console.Write(newArr[i] + " ");
            }
        }

        public abstract class A
        {
            public virtual string Print() { return "A"; }
        }

        public class B : A
        {
            public override string Print() { return "B"; }
        }

        public class C : B
        {
            public new string Print() { return "C"; }
        }

    }
}
