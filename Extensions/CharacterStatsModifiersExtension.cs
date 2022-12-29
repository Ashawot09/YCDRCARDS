using System;
using System.Runtime.CompilerServices;

namespace YCDRCARDS.Extensions
{
    // Token: 0x02000017 RID: 23
    public static class CharacterStatModifiersExtension
    {
        // Token: 0x06000064 RID: 100 RVA: 0x00004A06 File Offset: 0x00002C06
        public static CharacterStatModifiersAdditionalData GetAdditionalData(this CharacterStatModifiers statModifiers)
        {
            return CharacterStatModifiersExtension.data.GetOrCreateValue(statModifiers);
        }

        // Token: 0x06000065 RID: 101 RVA: 0x00004A14 File Offset: 0x00002C14
        public static void AddData(this CharacterStatModifiers statModifiers, CharacterStatModifiersAdditionalData value)
        {
            try
            {
                CharacterStatModifiersExtension.data.Add(statModifiers, value);
            }
            catch (Exception)
            {
            }
        }

        // Token: 0x04000037 RID: 55
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData> data = new ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData>();
    }
}
        
