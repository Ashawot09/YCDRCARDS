using System;
using Sonigon;
using Sonigon.Internal;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviors
{

    public class DescendMono : RayHitEffect
    {

        public override HasToReturn DoHitEffect(HitInfo hit)
        {
            if (!hit.transform)
            {
                return HasToReturn.canContinue;
            }
            PlayerJump component = hit.transform.GetComponent<PlayerJump>();
            DescendGravityMono component2 = hit.transform.GetComponent<DescendGravityMono>();
            if (hit.transform.GetComponent<DamageOverTime>())
            {
                if (component)
                {
                    component.Jump(false, 2f);
                }
                if (!component2)
                {
                    hit.transform.gameObject.AddComponent<DescendGravityMono>();
                    
                }
            }
            return HasToReturn.canContinue;
        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }

        public static SoundEvent fieldsound;

        private SoundParameterIntensity soundParameterIntensity = new SoundParameterIntensity(0.6f, UpdateMode.Continuous);
    }
}