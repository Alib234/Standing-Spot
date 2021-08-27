using RimWorld;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace StandingSpot
{
    [HarmonyPatch(typeof(Toils_LayDown),"ApplyBedThoughts")]
    static class StandingSpotThoughtPatch
    {
        private static void Prefix(Pawn actor)
        {
            if(actor.needs.mood==null)
            {
                return;
            }
            Building_Bed building_Bed=actor.CurrentBed();
            actor.needs.mood.thoughts.memories.RemoveMemoriesOfDef(StandingSpotThoughtDef.SleptStanding);
            if(actor.CurrentBed().def.HasModExtension<StandingSpotDefModExtension>())
            {
                actor.needs.mood.thoughts.memories.TryGainMemory(StandingSpotThoughtDef.SleptStanding,null,null);
            }
        }
    }
    //[HarmonyPatch(typeof(Toils_LayDown),"LayDown")]
    //static class StandingSpotStandingPatch
    //{
    //    public static Toil Postfix(TargetIndex bedOrRestSpotIndex,bool hasBed,bool lookForOtherJobs,bool canSleep=true,bool gainRestAndHealth=true,PawnPosture noBedLayingPosture=PawnPosture.LayingOnGroundNormal)
    //    {


    //    }
    //}

}