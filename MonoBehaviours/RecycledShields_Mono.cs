using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviors
{

    public class RecycledShields : ReversibleEffect
    {
        public float duration = 0;
        public override void OnStart()
        {
            this.player = this.data.player;
            Block block = this.block;
            block.BlockProjectileAction = (Action<GameObject, Vector3, Vector3>)Delegate.Combine(block.BlockProjectileAction, new Action<GameObject, Vector3, Vector3>(this.OnBlockProjectile));
            block.cdMultiplier = 0.25f;
            base.SetLivesToEffect(999999999);
        }

        private void OnBlockProjectile(GameObject projectile, Vector3 forward, Vector3 hitPos)
        {
            this.RecycleShot(this.duration);
            if (duration <= 0)
            {
                ApplyModifiers();
            }
            ColorEffect effect = player.gameObject.AddComponent<ColorEffect>();
            effect.SetColor(Color.cyan);
            
        }
        public void RecycleShot (float f)
        {
            duration = 2f;
        }

        public override void OnUpdate()
        {
            if (!(duration <= 0))
            {
                duration -= TimeHandler.deltaTime;  
            }
            else
            {
                ClearModifiers();
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
            }
        }

        public IEnumerator GameEnd()
        {
            base.Destroy();
            yield break;
        }

        public override void OnOnDestroy()
        {
        }


    }
    
}


