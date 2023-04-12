using System;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace YCDRCARDS.MonoBehaviours
{

    internal class TailwindEffect_Mono : ReversibleEffect
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
            characterStatModifiersModifier.movementSpeed_mult = 1.6f;
            characterStatModifiersModifier.jump_mult = 1.4f;
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


