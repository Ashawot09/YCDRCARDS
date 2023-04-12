using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using YCDRCARDS.MonoBehaviours;
using YCDRCards.Cards;
using YCDRCARDS.Extensions;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ClassesManagerReborn.Util;
using YCDRCards.Cards.Chaos;

namespace YCDRCards.Cards.Doped
{
    class Juiced : CustomCard
    {
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
//
            statModifiers.health = 1.16f;
            statModifiers.movementSpeed = 1.16f;
            statModifiers.jump = 1.16f;
            statModifiers.sizeMultiplier = 0.984f;
            block.cdMultiplier = 0.84f;
            gun.reloadTime = 0.84f;
            gun.gravity = 0.84f;
            gun.projectileSpeed = 1.16f;
            gun.projectielSimulatonSpeed = 1.16f;
            gun.damage = 1.16f;
            gun.attackSpeed = 0.84f;
            gun.knockback = 1.16f;
            gun.destroyBulletAfter = 1.16f;
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//

            gunAmmo.maxAmmo += 2;
            characterStats.lifeSteal += 0.16f;
            characterStats.numberOfJumps += 1;
            gun.reflects += 2;
            characterStats.regen += 2;
            characterStats.GetAdditionalData().MassModifier *= 80f;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = DopedClass.name;
        }

        protected override string GetTitle()
        {
            return "Juiced";
        }
        protected override string GetDescription()
        {
            return "Increase posistive stats and reduce negatives stats even more";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Positive stats",
                    amount = "+16%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Negative stats",
                    amount = "-16%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Jumps",
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bounces",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Regen",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.MagicPink;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
