using System;
using RimWorld;

namespace StandingSpot
{
    [DefOf]
    public static class StandingSpotThoughtDef
    {
        public static ThoughtDef SleptStanding;
        static StandingSpotThoughtDef()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(StandingSpotThoughtDef));
        }
    }
}
