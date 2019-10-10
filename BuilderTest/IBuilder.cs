using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();

        void Reset();

        Product GetProduct();
    }
}
