using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviors
{

    public class KarmaMono : ReversibleEffect
    {
        public override void OnStart()
        {
            this.reloadthing = new Action<GameObject, Vector3, Vector3>(this.GetDoBlockAction(this.player, this.block, this.data).Invoke);
            this.block.BlockProjectileAction = (Action<GameObject, Vector3, Vector3>)Delegate.Combine(this.block.BlockProjectileAction, this.reloadthing);
            base.SetLivesToEffect(999999999);
        }

        public override void OnUpdate()
        {
        }

        public Action<GameObject, Vector3, Vector3> GetDoBlockAction(Player player, Block block, CharacterData data)
        {
            return delegate (GameObject projectile, Vector3 forward, Vector3 hitPos)
            {
                ProjectileHit component = projectile.GetComponent<ProjectileHit>();
                component.movementSlow *= 0.95f;
                component.damage *= 2f; 
            };
        }

        public IEnumerator GameEnd()
        {
            base.Destroy();
            yield break;
        }

        public override void OnOnDestroy()
        {
            this.block.BlockProjectileAction = (Action<GameObject, Vector3, Vector3>)Delegate.Remove(this.block.BlockProjectileAction, this.reloadthing);
        }

        private Action<GameObject, Vector3, Vector3> reloadthing;
    }
}
