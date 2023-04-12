using UnboundLib.Cards;
using UnityEngine;
using BepInEx;
using YCDRCARDS.MonoBehaviours;
using YCDRCards.Cards;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ClassesManagerReborn.Util;
using UnboundLib;
using System.Collections.Generic;
using System.Linq;
using System;

namespace YCDRCards.Cards.Skybound
{
    class Napalm : CustomCard
    {

        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<NapalmBuffMono>();

            
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            var mono = player.gameObject.GetOrAddComponent<NapalmBuffMono>();
            UnityEngine.GameObject.Destroy(mono);
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = Skyboundclass.name;
        }

        protected override string GetTitle()
        {
            return "Napalm";
        }
        protected override string GetDescription()
        {
            return "While flying, Burn enemies over 2 secs";
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
                    stat = "Damage when flying",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
               
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
