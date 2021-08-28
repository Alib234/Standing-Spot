using HarmonyLib;
using RimWorld;
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
    /*failed attempt at making pawns stand while sleeping, for some reason this gets overriden or if changed a bit breaks the whole laydown toil.
    Also would prolly need to make a new job for posture anyways, if someone wants to do this, do it, cuz am too dum.
    */

    //[HarmonyPatch(typeof(Toils_LayDown),"LayDown")]
    //static class StandingSpotStandingPatch
    //{
    //    public static Toil Postfix(TargetIndex bedOrRestSpotIndex,Toil __result)
    //    {
    //        Toil layDown = new Toil();
    //        if(__result.actor.def.HasModExtension<StandingSpotDefModExtension>())
    //        {
    //            Log.Message("testinif");
    //            __result.actor.jobs.posture=PawnPosture.Standing;
    //            __result.actor.mindState.lastBedDefSleptIn=__result.actor.CurrentBed().def;
    //            return __result;
    //        }
    //        return __result;
    //    }
    //}
}
