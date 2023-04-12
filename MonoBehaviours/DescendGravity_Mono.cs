using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviors
{

    public class DescendGravityMono : ReversibleEffect
    {

        public override void OnOnEnable()
        {
            if (this.colorEffect != null)
            {
                this.colorEffect.Destroy();
            }
        }


        public override void OnStart()
        {
            this.characterStatModifiersModifier.movementSpeed_mult *= 0.75f;
            this.gravityModifier.gravityForce_mult = 1.75f;
            this.characterStatModifiersModifier.jump_mult = 0.75f;
            this.colorEffect = this.player.gameObject.AddComponent<ReversibleColorEffect>();
            this.colorEffect.SetColor(this.color);
            this.colorEffect.SetLivesToEffect(1);
            this.ResetEffectTimer();
            this.ResetTimer();
        }


        public override void OnUpdate()
        {
            if (Time.time >= this.startTime + this.updateDelay)
            {
                this.ResetTimer();
                if (Time.time >= this.timeOfLastEffect + this.effectCooldown)
                {
                    base.Destroy();
                    this.colorEffect.Destroy();
                }
                if (base.GetComponent<Player>().data.dead || base.GetComponent<Player>().data.health <= 0f || !base.GetComponent<Player>().gameObject.activeInHierarchy)
                {
                    this.ResetTimer();
                    base.Destroy();
                }
            }
        }


        public override void OnOnDisable()
        {
            if (this.colorEffect != null)
            {
                this.colorEffect.Destroy();
                this.ResetEffectTimer();
                this.ResetTimer();
            }
        }


        public override void OnOnDestroy()
        {
            if (this.colorEffect != null)
            {
                this.colorEffect.Destroy();
                this.ResetEffectTimer();
                this.ResetTimer();
            }
        }


        private void ResetTimer()
        {
            this.startTime = Time.time;
        }


        private void ResetEffectTimer()
        {
            this.timeOfLastEffect = Time.time;
        }


        private readonly Color color = Color.blue;


        private ReversibleColorEffect colorEffect;

  
        private readonly float updateDelay = 0.1f;


        private readonly float effectCooldown = 2.5f;


        private float startTime;


        private float timeOfLastEffect;
    }
}
