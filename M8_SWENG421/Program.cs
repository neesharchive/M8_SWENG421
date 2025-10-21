using System;

namespace TvSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Buyer b = new Buyer(new TV());     // brandless start
            Customer c = new Customer(new LG_TV()); // start with LG via interface

            // Buyer tests (brandless family)
            b.Try(null, 350);          // expect Smart_TV ($300)
            b.Try("UltraHD", 450);     // expect UltraHD_TV ($400)
            b.Try("TV", 180);          // none available

            // Customer tests (can swap brand by reassigning tvif to a root of that family)
            c.Try("Smart", 360);       // LG Smart ($350)
            c.tvif = new Sony_TV();    // switch to Sony but still via TV_IF
            c.Try(null, 480);          // best Sony within $480
            c.Try("TV", 500);          // stays Regular TV if chosen

            // Single-point brand rename affects all LG objects
            LG_TV.SetBrandName("LG Electronics");
            c.tvif = new LG_TV();
            c.Try("UltraHD", 450);     // shows updated brand name
        }
    }
}
