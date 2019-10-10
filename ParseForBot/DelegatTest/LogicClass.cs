using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParseForBot.DelegatTest
{
    delegate void ShowMessage(string message);

    class LogicClass
    {
        public void Move(int interval, string text)
        {
            for(int i=0; i<interval; i++)
            {
                testHandler(this, new TestHandler(String.Format("{0} get walked {1} miles", text, i)));
                Thread.Sleep(1000);
            }
        }

        public event EventHandler<TestHandler> testHandler;

    }
}
