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
    public class OneBulletBuffMono : ReversibleEffect
    {
        public override void OnStart()
        {
            ammoNorm = this.gunAmmo.maxAmmo;

            //(useful as base oneshot buff code - this.gunStatModifier.damage_add = ((0.135f * (ammoNorm - 1f)));
           this.gunAmmoStatModifier.maxAmmo_add = -this.gunAmmo.maxAmmo + 1;
        }

        public override void OnOnDisable()
        {
            Destroy();
        }

        public void OnDestroy()
        {

        }
        public float asBonus;
        public int ammoNorm;
    }
}
