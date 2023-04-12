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

namespace YCDRCards.Cards
{
    class ItDies : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
//
            gun.damage = 1.6f;
            gun.percentageDamage = 0.25f;
            gun.projectileColor = Color.red;
            statModifiers.movementSpeed = 0.65f;
            gun.projectileSpeed = 4f;
            gun.knockback = 25f;
            gun.reloadTime = 2f;
            gun.attackSpeed = 1.25f;
        }   
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

            gunAmmo.maxAmmo = 1;

            player.gameObject.AddComponent<OneBulletMono>();

            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList();
            ObjectsToSpawn objectsToSpawn = ((GameObject)Resources.Load("0 cards/Timed detonation")).GetComponent<Gun>().objectsToSpawn[0];
            list.Add(
                objectsToSpawn
            );
            gun.objectsToSpawn = list.ToArray();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            if (player.transform.gameObject.GetComponent<OneBulletMono>() != null)
            {
                Destroy(player.transform.gameObject.GetComponent<OneBulletMono>());
            }  
        }

        protected override string GetTitle()
        {
            return "It dies";
        }
        protected override string GetDescription()
        {
            return "If it lives, it dies";
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
                    stat = "DMG",
                    amount = "160%, +25% of enemy health",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Reload time",
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "=1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Projectile Speed",
                    amount = "+400%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Movement Speed",
                    amount = "-35%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
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
