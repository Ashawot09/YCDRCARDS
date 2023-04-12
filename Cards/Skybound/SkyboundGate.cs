using UnboundLib.Cards;
using UnityEngine;
using BepInEx;
using YCDRCARDS.MonoBehaviours;
using YCDRCards.Cards;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ClassesManagerReborn.Util;
using UnboundLib;

namespace YCDRCards.Cards.Skybound
{
    class SkyboundGate : CustomCard
    {

        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.gravity = 0.35f;
            statModifiers.jump = 0.55f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            statModifiers.numberOfJumps = +6;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>();
        }

        protected override string GetTitle()
        {
            return "Skybound";
        }
        protected override string GetDescription()
        {
            return "Gain extended flight time and unlock new aerial cards!";
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
                    positive = true,
                    stat = "Jumps",
                    amount = "+6",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Jump Height",
                    amount = "35%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Gravity",
                    amount = "35%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
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
