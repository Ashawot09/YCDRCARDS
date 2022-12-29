using System;

namespace YCDRCARDS.Extensions
{
    // Token: 0x02000016 RID: 22
    [Serializable]
    public class CharacterStatModifiersAdditionalData
    {
        // Token: 0x06000063 RID: 99 RVA: 0x00004970 File Offset: 0x00002B70
        public CharacterStatModifiersAdditionalData()
        {
            this.MassModifier = 1f;

            this.willpower = 0f;
        }

        // Token: 0x0400002B RID: 43
        public float MassModifier;



        // Token: 0x0400002F RID: 47
        public float willpower;

    }
}
        
