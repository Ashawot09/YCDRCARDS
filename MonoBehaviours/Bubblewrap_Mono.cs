using System;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;
using ModdingUtils.MonoBehaviours;

namespace YCDRCARDS.MonoBehaviors
{
    public class BubblewrapMono : DealtDamageEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            bool flag = selfDamage || (damagedPlayer != null && damagedPlayer.teamID == base.gameObject.GetComponent<Player>().teamID);
            if (flag)
            {
                bool flag2 = damagedPlayer.data.health - damage.magnitude <= 0f;
                if (flag2)
                {
                    damagedPlayer.data.healthHandler.Heal(damage.magnitude);
                }
                else
                {
                    Unbound.Instance.ExecuteAfterFrames(2, delegate
                    {
                        damagedPlayer.data.healthHandler.Heal(damage.magnitude);
                    });
                }
                Unbound.Instance.ExecuteAfterFrames(2, delegate
                {
                    damagedPlayer.data.healthHandler.Heal(damage.magnitude / 4f);
                });
            }
        }


        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
}