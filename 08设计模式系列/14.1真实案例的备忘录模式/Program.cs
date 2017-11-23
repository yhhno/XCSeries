using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Leaflet> leaflets = new List<ConsoleApplication22.Leaflet>();

            leaflets.Add(new Leaflet() { CustomerList = new List<int>() });


            Caretaker taker = new Caretaker();

            foreach (var leaflet in leaflets)
            {
                var memento = leaflet.CreateMemento();

                taker.MementoList.Add(memento);
            }
        }
    }
}
