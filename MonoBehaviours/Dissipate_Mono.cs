using System;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;
using ModdingUtils.MonoBehaviours;

namespace YCDRCARDS.MonoBehaviors
{
    public class DissipateMono : WasDealtDamageEffect
    {
        public override void WasDealtDamage(Vector2 damage, bool selfDamage)
        {

            
            bool flag = selfDamage != null;
               if (flag)
                {
   
                    //bool flag2 = damagedPlayer.data.health >= player.data.maxHealth * 0.75;
                    //bool flag3 = CharacterData.healthHandler - damage.magnitude <= damagedPlayer.data.maxHealth * 0.25;
       
      //              if (flag2)
        //            {
          //              if (flag3)
            //            {
              //          damagedPlayer.data.healthHandler.Heal(damagedPlayer.data.maxHealth * 0.25f);
                //        }
                  //  }


                }
         }
        

        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
}