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
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using RarityLib.Utils;
using ClassesManagerReborn.Util;

namespace YCDRCards.Cards.Doped
{
    class OlympianAthlete : CustomCard
    {
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            //
            cardInfo.allowMultiple = false;
            statModifiers.health = 1.5f;
            statModifiers.movementSpeed = 1.5f;
            statModifiers.jump = 1.5f;
            statModifiers.sizeMultiplier = 0.95f;
            block.cdMultiplier = 0.5f;
            gun.reloadTime = 0.5f;
            gun.gravity = 0.5f;
            gun.projectileSpeed = 1.5f;
            gun.projectielSimulatonSpeed = 1.5f;
            gun.damage = 1.5f;
            gun.attackSpeed = 0.5f;
            gun.knockback = 1.5f;
            gun.destroyBulletAfter = 1.5f;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//

            gunAmmo.maxAmmo += 5;
            characterStats.lifeSteal += 0.5f;
            characterStats.numberOfJumps += 3;
            gun.reflects += 5;
            characterStats.regen += 10;

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
            return "Olympian";
        }
        protected override string GetDescription()
        {
            return "Increase posistive stats and reduce negatives stats by a huge amount";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return RarityUtils.GetRarity("Legendary");
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Positive stats",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Negative stats",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Jumps",
                    amount = "+3",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bounces",
                    amount = "+5",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bursts",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullets",
                    amount = "+1",
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
