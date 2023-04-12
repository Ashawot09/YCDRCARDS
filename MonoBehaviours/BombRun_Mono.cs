using System;
using System.Collections.Generic;
using System.Linq;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviours
{

    internal class BombRun_Mono : ReversibleEffect
    {
        public override void OnOnDestroy()

        {
            PlayerJump jump = data.jump;
            jump.JumpAction = (Action)Delegate.Remove(jump.JumpAction, new Action(OnJump));
        }

        private void OnJump()
        {
            bool flag = duration <= 0f;
            if (flag)
            {
                ApplyModifiers();
            }
            duration = 1f;
            
        }

        public override void OnStart()
        {
            gunStatModifier.damage_mult = 1.3f;
            gunStatModifier.gravity_mult = 1.7f;
            gunStatModifier.projectileSpeed_mult = 0.7f;
            gunStatModifier.numberOfProjectiles_add = 2;
            gunStatModifier.spread_mult = 0.08f;


            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList();
            ObjectsToSpawn objectsToSpawn = ((GameObject)Resources.Load("0 cards/Explosive bullet")).GetComponent<Gun>().objectsToSpawn[0];
            list.Add(
                objectsToSpawn
            );
            gun.objectsToSpawn = list.ToArray();

            //modifier
            PlayerJump jump = data.jump;
            jump.JumpAction = (Action)Delegate.Combine(jump.JumpAction, new Action(OnJump));
            SetLivesToEffect(int.MaxValue);
        }

        public override void OnUpdate()
        {
            bool flag = duration > 0f;
            if (flag)
            {
                duration -= TimeHandler.deltaTime;
            }
            else
            {
                ClearModifiers(true);
                UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
            }
        }

        public override void OnOnDisable()
        {
            duration = 0f;
            ClearModifiers(true);
            UnityEngine.GameObject.Destroy(this.gameObject.GetOrAddComponent<ColorEffect>());
        }

        private float duration = 0f;
    }
}


