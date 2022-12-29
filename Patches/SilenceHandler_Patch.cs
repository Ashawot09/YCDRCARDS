using HarmonyLib;
using System;
using YCDRCARDS.Extensions;

namespace YCDRCARDS.Patches
{
    // Token: 0x0200002F RID: 47
    [HarmonyPatch(typeof(SilenceHandler))]
    internal class SilenceHandler_Patch
    {
        // Token: 0x0600009B RID: 155 RVA: 0x00005C18 File Offset: 0x00003E18
        [HarmonyPrefix]
        [HarmonyPatch("Update")]
        private static void WillpowerSpeedUp(SilenceHandler __instance, CharacterData ___data)
        {
            if (___data.stats.GetAdditionalData().willpower != 0f && ___data.silenceTime > 0f)
            {
                ___data.silenceTime -= TimeHandler.deltaTime * ___data.stats.GetAdditionalData().willpower;
            }
        }
    }
}

