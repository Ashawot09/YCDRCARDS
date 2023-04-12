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

namespace YCDRCards.Cards
{
    class BigBoi : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
//
            statModifiers.movementSpeed = 0.95f;
            statModifiers.sizeMultiplier = 1.08f;
            statModifiers.health = 1.90f;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//
        }

        protected override string GetTitle()
        {
            return "BigBoi";
        }
        protected override string GetDescription()
        {
            return "Nah, chunky is funky";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Size",
                    amount = "+9%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Speed",
                    amount = "-5%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+90%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
