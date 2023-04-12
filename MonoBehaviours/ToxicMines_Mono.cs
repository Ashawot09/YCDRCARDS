using System;
using Sonigon;
using UnityEngine;

namespace CR.MonoBehaviors
{

    public class ToxicMines_Mono : RayHitEffect
    {

        private void Start()
        {
            if (base.GetComponentInParent<ProjectileHit>() != null)
            {
                base.GetComponentInParent<ProjectileHit>().bulletCanDealDeamage = false;
            }
        }

        public override HasToReturn DoHitEffect(HitInfo hit)
        {


            if (!hit.transform)
            {
                return HasToReturn.canContinue;
            }
            base.transform.root.GetComponentsInChildren<ToxicMines_Mono>();
            ProjectileHit componentInParent = base.GetComponentInParent<ProjectileHit>();
            DamageOverTime component = hit.transform.GetComponent<DamageOverTime>();
            if (component)
            {
                component.TakeDamageOverTime(componentInParent.damage * base.transform.forward * 1f, base.transform.position, this.time, this.interval, this.color, this.soundEventDamageOverTime, base.GetComponentInParent<ProjectileHit>().ownWeapon, base.GetComponentInParent<ProjectileHit>().ownPlayer, true);
            }
            return HasToReturn.canContinue;

            
        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }

        [Header("Sounds")]
        public SoundEvent soundEventDamageOverTime;

        [Header("Settings")]
        public float time = 4f;

        public float interval = 0.35f;

        public Color color = Color.green;
    }
}