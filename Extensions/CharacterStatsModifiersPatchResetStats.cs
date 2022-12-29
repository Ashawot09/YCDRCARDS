using System;
using HarmonyLib;

namespace YCDRCARDS.Extensions
{
    // Token: 0x02000018 RID: 24
    [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
    internal class CharacterStatModifiersPatchResetStats
    {
        // Token: 0x06000067 RID: 103 RVA: 0x00004A50 File Offset: 0x00002C50
        private static void Prefix(CharacterStatModifiers __instance)
        {
            __instance.GetAdditionalData().MassModifier = 1f;
            __instance.GetAdditionalData().willpower = 0f;
        }
    }

}

