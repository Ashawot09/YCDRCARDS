using HarmonyLib;
using System;
using YCDRCARDS.Extensions;

namespace YCDRCARDS.Patches
{
    // Token: 0x02000030 RID: 48
    [HarmonyPatch(typeof(StunHandler))]
    internal class StunHandler_Patch
    {
        // Token: 0x0600009D RID: 157 RVA: 0x00005C78 File Offset: 0x00003E78
        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        private static void WillpowerSpeedUp(StunHandler __instance, CharacterData ___data)
        {
            if (___data.stats.GetAdditionalData().willpower != 0f && ___data.stunTime > 0f)
            {
                ___data.stunTime -= TimeHandler.deltaTime * ___data.stats.GetAdditionalData().willpower;
            }
        }
    }
}
        
