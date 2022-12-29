using HarmonyLib;
using System;
using UnboundLib;
using YCDRCARDS.Extensions;

namespace YCDRCARDS.Patches
{
    // Token: 0x02000026 RID: 38
    [HarmonyPatch(typeof(CharacterStatModifiers))]
    internal class CharacterStatModifiers_Patch
    {
        // Token: 0x06000084 RID: 132 RVA: 0x000055D4 File Offset: 0x000037D4
        [HarmonyPostfix]
        [HarmonyPriority(800)]
        [HarmonyPatch("ConfigureMassAndSize")]
        private static void MassAdjustment(CharacterStatModifiers __instance, CharacterData ___data)
        {
            if (__instance.GetAdditionalData().MassModifier != 1f)
            {
                float num = (float)___data.playerVel.GetFieldValue("mass");
                float massModifier = __instance.GetAdditionalData().MassModifier;
                float num2 = num * massModifier;
                ___data.playerVel.SetFieldValue("mass", num2);
            }
        }
    }
}

