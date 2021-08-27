using HarmonyLib;
using Verse;


namespace StandingSpot
{
    [StaticConstructorOnStartup]
    public class StandingSpot:Mod
    {
        public StandingSpot(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("Alib234.StandingSpot");
            harmony.PatchAll();
        }
    }
}