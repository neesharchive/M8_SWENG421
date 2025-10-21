using System;

namespace TvSystem
{
    public class Sony_TV : TV_IF
    {
        protected int MSRP;
        protected string Type;

        protected static string BrandName = "Sony";

        protected static readonly int PRICE_TV = 280;
        protected static readonly int PRICE_SMART = 380;
        protected static readonly int PRICE_ULTRA = 480;

        public Sony_TV()
        {
            MSRP = PRICE_TV;
            Type = "Regular";
        }

        protected Sony_TV(int price, string type)
        {
            MSRP = price;
            Type = type;
        }

        // inner protected subclasses
        protected class Sony_Smart_TV : Sony_TV
        {
            public Sony_Smart_TV() : base(PRICE_SMART, "Smart") { }
            protected virtual double getPowerUsage() => 5.15;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} PowerUsage={getPowerUsage()}W";
        }

        protected class Sony_UltraHD_TV : Sony_TV
        {
            public Sony_UltraHD_TV() : base(PRICE_ULTRA, "UltraHD") { }
            protected virtual int getResolution() => 4;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} Resolution={getResolution()}K_HD";
        }

        public static void SetBrandName(string newName) => BrandName = newName;

        public virtual TV_IF replenish(string type, int budget)
        {
            Sony_TV[] options = new Sony_TV[] { new Sony_TV(), new Sony_Smart_TV(), new Sony_UltraHD_TV() };

            bool TypeMatches(Sony_TV t)
            {
                if (type == null) return true;
                if (type.Equals("TV", StringComparison.OrdinalIgnoreCase))
                    return t.getType() == "Regular";
                return t.getType().Equals(type, StringComparison.OrdinalIgnoreCase);
            }

            Sony_TV best = null;
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
        public virtual string getBrand() => BrandName;
    }
}
