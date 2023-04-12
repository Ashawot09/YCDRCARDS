using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using YCDRCards.Cards;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using YCDRCARDS.MonoBehaviors;

namespace YCDRCards.Cards
{
    class Dissipate : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<DissipateMono>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<DissipateMono>();
            UnityEngine.GameObject.Destroy(mono);
        }

        protected override string GetTitle()
        {
            return "Dissipate";
        }
        protected override string GetDescription()
        {
            return "You can only take 75% of your max healh per damage instance";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Effect",
                    amount = "No",
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
