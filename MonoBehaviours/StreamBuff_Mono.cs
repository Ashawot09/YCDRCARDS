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
    public class StreamBuffMono : ReversibleEffect
    {
        public override void OnStart()
        {

            ProjNorm = this.gun.numberOfProjectiles;
            SpreadNorm = this.gun.spread;

            //(useful as base oneshot buff code - this.gunStatModifier.damage_add = ((0.135f * (ammoNorm - 1f)));
            this.gunStatModifier.spread_add = -this.gun.spread + 0;
            this.gunStatModifier.numberOfProjectiles_add = -this.gun.numberOfProjectiles + 1;
        }

        public override void OnOnDisable()
        {
            Destroy();
        }

        public void OnDestroy()
        {

        }
        public float asBonus;
        public int ProjNorm;
        public float SpreadNorm;
    }
}
