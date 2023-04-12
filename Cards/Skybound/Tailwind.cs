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
    class Tailwind : CustomCard
    {

        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.gravity = 0.9f;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            statModifiers.numberOfJumps = +8;
            var mono = player.gameObject.GetOrAddComponent<TailwindEffect_Mono>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<TailwindEffect_Mono>();
            UnityEngine.GameObject.Destroy(mono);
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = Skyboundclass.name;
        }

        protected override string GetTitle()
        {
            return "Tailwind";
        }
        protected override string GetDescription()
        {
            return "Gain speed while midair and increase flight time";
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
                    amount = "+8",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Gravity",
                    amount = "-10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Speed while midair",
                    amount = "+60%",
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
