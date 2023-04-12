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
using static CardInfoStat;
using static UnityEngine.Random;

namespace YCDRCards.Cards
{
    class Sprint : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {

            cardInfo.allowMultiple = false;
            block.cdMultiplier = 0.9f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

            var mono = player.gameObject.GetOrAddComponent<SprintMono>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

            var mono = player.gameObject.GetOrAddComponent<SprintMono>();
            UnityEngine.GameObject.Destroy(mono);
        }

        protected override string GetTitle()
        {
            return "Sprint";
        }
        protected override string GetDescription()
        {
            return "Burst of speed and jump after blocking";
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
                    stat = "",
                    amount = "",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "-10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
