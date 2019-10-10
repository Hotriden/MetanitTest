using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvachDaynNeugominius
{
    delegate Person PersonFactory(string name);
    delegate void ClientInfo(Client client);

    class Variantnost_Delegates
    {
        static void Main(string[] args)
        {
            PersonFactory personDel;
            personDel = BuildClient; // ковариантность
            Person p = personDel("Tom");
            Console.WriteLine(p.Name);
            Console.Read();

            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            Client client = new Client { Name = "Alice" };
            clientInfo(client);
            Console.Read();

        }
        private static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }

        private static void GetPersonInfo(Person p)
        {
            Console.WriteLine(p.Name);
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
    class Client : Person { }
}
