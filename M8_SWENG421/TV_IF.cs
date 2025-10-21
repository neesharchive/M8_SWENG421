using System;

namespace TvSystem
{
    public interface TV_IF
    {
        TV_IF replenish(string type, int budget);   // returns TV_IF (per spec)
        string getInfo();
        string getType();
        int getPrice();
        string getBrand();
    }
}
