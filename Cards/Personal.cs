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
    class Personal : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {

            gun.reloadTime = 1.15f;
            var obj = new GameObject("NoCollide");
            obj.hideFlags = HideFlags.HideAndDontSave;
            obj.AddComponent<NoBulletCollide>();
            gun.objectsToSpawn = new[]
            {
                new ObjectsToSpawn
                {
                    AddToProjectile = obj,
                }
            };

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

            gunAmmo.maxAmmo += 5;
            gun.numberOfProjectiles += 4;
            gun.destroyBulletAfter = 0.4f;
            gun.projectileSpeed = 2f;
            gun.spread = 0.2f;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

        }

        protected override string GetTitle()
        {
            return "Personal";
        }
        protected override string GetDescription()
        {
            return "Blast them with degenerating bursts";
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
                    stat = "Ammo",
                    amount = "+5",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Projectiles",
                    amount = "+4",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Time",
                    amount = "+15%",
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
