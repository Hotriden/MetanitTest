using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    public class Program
    {
        public ConcreteBuilder builder = new ConcreteBuilder();
        public int x = 5;
        static void Main(string[] args)
        {
            var builder = new ConcreteBuilder();
            var director = new Director(builder);
            Console.WriteLine("build minimal: ");
            director.buildMinimalValueProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.Write("build full: ");
            director.buildFullValueProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Custom product: ");
            builder.BuildPartA();
            builder.BuildPartB();
            Console.WriteLine(builder.GetProduct().ListParts());
            Console.ReadKey();
        }
    }
}
