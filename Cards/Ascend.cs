using System;
using System.Collections.Generic;
using System.Linq;
using YCDRCARDS.MonoBehaviours;
using UnboundLib.Cards;
using UnityEngine;
using YCDRCARDS.MonoBehaviors;

namespace YCDRCards.Cards
{

    public class Ascend : CustomCard
    {

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
        }


        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.projectileColor = Color.magenta;

            List<ObjectsToSpawn> list = Enumerable.ToList<ObjectsToSpawn>(gun.objectsToSpawn);
            list.Add(new ObjectsToSpawn
            {
                AddToProjectile = new GameObject("AscendHit", new Type[]
                {
                    typeof(AscendMono)
                })
            });
            gun.objectsToSpawn = list.ToArray();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }


        protected override string GetTitle()
        {
            return "Ascend";
        }


        protected override string GetDescription()
        {
            return "Bullets reverse gravity for 2.5 seconds.";
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
                new CardInfoStat
                {
                    positive = true,
                    stat = "",
                    amount = "",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
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