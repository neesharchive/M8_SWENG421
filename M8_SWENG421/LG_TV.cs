using System;

namespace TvSystem
{
    public class LG_TV : TV
    {
        protected static string BrandName = "LG";

        protected static readonly int PRICE_TV = 250;
        protected static readonly int PRICE_SMART = 350;
        protected static readonly int PRICE_ULTRA = 450;

        public LG_TV()
        {
            MSRP = PRICE_TV;
            Type = "Regular";
        }

        protected LG_TV(int price, string type)
        {
            MSRP = price;
            Type = type;
        }

        protected class LG_Smart_TV : LG_TV
        {
            public LG_Smart_TV() : base(PRICE_SMART, "Smart") { }
            protected virtual double getPowerUsage() => 6.35;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} PowerUsage={getPowerUsage()}W";
        }

        protected class LG_UltraHD_TV : LG_TV
        {
            public LG_UltraHD_TV() : base(PRICE_ULTRA, "UltraHD") { }
            protected virtual int getResolution() => 4;
            public override string getInfo() =>
                $"Brand={getBrand()} Type={getType()} Price=${getPrice()} Resolution={getResolution()}K_HD";
        }

        public static void SetBrandName(string newName) => BrandName = newName;

        public override TV replenish(string type, int budget)
        {
            LG_TV[] options = new LG_TV[] { new LG_TV(), new LG_Smart_TV(), new LG_UltraHD_TV() };

            bool TypeMatches(LG_TV t)
            {
                if (type == null) return true;
                if (type.Equals("TV", StringComparison.OrdinalIgnoreCase))
                    return t.getType() == "Regular";
                return t.getType().Equals(type, StringComparison.OrdinalIgnoreCase);
            }

            LG_TV best = null;
            foreach (var cand in options)
            {
                if (!TypeMatches(cand)) continue;
                if (cand.MSRP > budget) continue;
                if (best == null || cand.MSRP > best.MSRP) best = cand;
            }
            return best;
        }

        public override string getBrand() => BrandName;
    }
}
