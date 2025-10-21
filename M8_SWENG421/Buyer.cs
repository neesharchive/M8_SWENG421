using System;

namespace TvSystem
{
    public class Buyer
    {
        public TV tv;   // association to TV (brandless), per spec

        public Buyer(TV initial) { tv = initial; }

        public void Try(string type, int budget)
        {
            TV next = tv.replenish(type, budget) as TV;
            if (next == null)
            {
                Console.WriteLine("Buyer: no availability");
                return;
            }
            tv = next;
            Console.WriteLine("Buyer -> " + tv.getInfo());
        }
    }
}
