using System;

namespace TvSystem
{
    public class TV : TV_IF
    {
        // fields required by spec
        protected int MSRP;
        protected string Type;

        // MSRP table
        protected static readonly int PRICE_TV = 200;
        protected static readonly int PRICE_SMART = 300;
        protected static readonly int PRICE_ULTRA = 400;

        public TV()
        {
            MSRP = PRICE_TV;
            Type = "Regular";
        }

        protected TV(int price, string type)
        {
            MSRP = price;
            Type = type;
        }

        // ---- inner protected subclasses ----
        protected class Smart_TV : TV
        {
            public Smart_TV() : base(PRICE_SMART, "Smart") { }
            protected virtual double getPowerUsage() => 5.5;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} PowerUsage={getPowerUsage()}W";
        }

        protected class UltraHD_TV : TV
        {
            public UltraHD_TV() : base(PRICE_ULTRA, "UltraHD") { }
            protected virtual int getResolution() => 2;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} Resolution={getResolution()}K_HD";
        }

        //kk-I understood the directions to indent for a TV object to be returned here ==> "The TV class has a field “MSRP: int” and another field “Type: string” with getters and setters. It
also has a “+replenish(string: type, budget: int): TV” method,"
        // ---- TV_IF implementation ----
        public virtual TV_IF replenish(string type, int budget)
        {
            // candidates only from THIS family
            TV[] options = new TV[] { new TV(), new Smart_TV(), new UltraHD_TV() };

            bool TypeMatches(TV t)
            {
                if (type == null) return true;
                if (type.Equals("TV", StringComparison.OrdinalIgnoreCase))
                    return t.getType() == "Regular";
                return t.getType().Equals(type, StringComparison.OrdinalIgnoreCase);
            }

            TV best = null;
            foreach (var cand in options)
            {
                if (!TypeMatches(cand)) continue;
                if (cand.MSRP > budget) continue;
                if (best == null || cand.MSRP > best.MSRP) best = cand;   // “closest and below”
            }
            return best;   // may be null
        }

        public virtual string getInfo() =>
            $"Brand={getBrand()} Type={getType()} Price=${getPrice()}";

        // getters per spec
        public virtual string getType() => Type;
        public virtual int getPrice() => MSRP;
        public virtual string getBrand() => "Brandless";
    }
}
