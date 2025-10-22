using System;

namespace TvSystem
{
    public interface TV_IF
    {
        TV replenish(string type, int budget);
        string getInfo();
        string getType();
        int getPrice();
        string getBrand();
    }
}
