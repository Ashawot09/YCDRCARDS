using System;
using System.Collections.Generic;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ModdingUtils.MonoBehaviours;
using ModdingUtils.Extensions;
using YCDRCards.Cards;

namespace YCDRCARDS.MonoBehaviours
{
    internal class SprintMono : ReversibleEffect
    {
        public float duration = 0;

        public override void OnOnDestroy()
        {
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Remove(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
        }
        private void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            if (duration <=0)
            {
                ApplyModifiers();
            }
            duration = 1.25f;
            ColorEffect effect = player.gameObject.AddComponent<ColorEffect>();
            effect.SetColor(Color.cyan);
        }
        public override void OnStart()
        {
            characterStatModifiersModifier.movementSpeed_mult = 2;
            characterStatModifiersModifier.jump_mult = 1.3f;
            block.BlockAction = (Action<BlockTrigger.BlockTriggerType>)Delegate.Combine(block.BlockAction, new Action<BlockTrigger.BlockTriggerType>(OnBlock));
            SetLivesToEffect(int.MaxValue);
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
            public override void OnOnDisable()
        {
            duration = 0;
        }
    }
}
