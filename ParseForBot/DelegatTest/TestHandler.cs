using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseForBot.DelegatTest
{
    class TestHandler
    {
        public string Message { get; private set; }

        public TestHandler(string mes)
        {
            Message = mes;
        }
    }
}
