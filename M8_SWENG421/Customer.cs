using System;

namespace TvSystem
{
    public class Customer
    {
        public TV_IF tvif;   // association to interface, allows any brand family

        public Customer(TV_IF initial) { tvif = initial; }

        public void Try(string type, int budget)
        {
            TV_IF next = tvif.replenish(type, budget);
            if (next == null)
            {
                Console.WriteLine("Customer: no availability");
                return;
            }
            tvif = next;
            Console.WriteLine("Customer -> " + tvif.getInfo());
        }
    }
}
