using System;
using System.Collections.Generic;
using System.Linq;
using YCDRCARDS.MonoBehaviors;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviours
{

    internal class NapalmBuffMono : ReversibleEffect
    {
        public override void OnOnDestroy()

        {
            PlayerJump jump = data.jump;
            jump.JumpAction = (Action)Delegate.Remove(jump.JumpAction, new Action(OnJump));
            UnityEngine.Object.Destroy(this);
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
            gunStatModifier.damage_mult = 1.5f;
            gunStatModifier.projectileColor = Color.red;

            List<ObjectsToSpawn> list = Enumerable.ToList<ObjectsToSpawn>(gun.objectsToSpawn);
            list.Add(new ObjectsToSpawn
            {
                AddToProjectile = new GameObject("Napalm", new Type[]
                {
                    typeof(NapalmMono)
                })
            });
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


