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
    public class AlwaysBlockableBuffMono : ReversibleEffect
    {
        public override void OnStart()
        {
            BlockNorm = this.gun.unblockable;

            //(useful as base oneshot buff code - this.gunStatModifier.damage_add = ((0.135f * (ammoNorm - 1f)));
            this.gun.unblockable = false;
        }

        public override void OnOnDisable()
        {
            Destroy();
        }

        public void OnDestroy()
        {

        }
        public float asBonus;
        public bool BlockNorm;
    }
}
