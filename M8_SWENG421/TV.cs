using System;

namespace TvSystem
{
    public class TV : TV_IF
    {
        protected int MSRP;
        protected string Type;

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

        public virtual TV replenish(string type, int budget)
        {
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
                if (best == null || cand.MSRP > best.MSRP) best = cand;
            }
            return best;
        }

        public virtual string getInfo() =>
            $"Brand={getBrand()} Type={getType()} Price=${getPrice()}";

        public virtual string getType() => Type;
        public virtual int getPrice() => MSRP;
        public virtual string getBrand() => "Brandless";
    }
}
