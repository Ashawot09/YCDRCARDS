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
    class Salvo : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
//
            cardInfo.allowMultiple = false;
            gun.attackSpeed = 1.2f;
            gun.damage = 0.8f;
            gun.projectielSimulatonSpeed = 0.45f;
            gun.projectileSpeed = 1.8f;
            gun.numberOfProjectiles = 4;
            gun.reloadTime = 2f;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//
            gunAmmo.maxAmmo += 9;
            gun.spread = 0;
            gun.spread += 0.35f;
            gun.recoilMuiltiplier += 0.1f;

            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList();
            ObjectsToSpawn objectsToSpawn = ((GameObject)Resources.Load("0 cards/Explosive bullet")).GetComponent<Gun>().objectsToSpawn[0];
            ObjectsToSpawn objectsToSpawn2 = ((GameObject)Resources.Load("0 cards/Timed detonation")).GetComponent<Gun>().objectsToSpawn[0];
            ObjectsToSpawn objectsToSpawn3 = ((GameObject)Resources.Load("0 cards/Homing")).GetComponent<Gun>().objectsToSpawn[0];
            list.Add(
                objectsToSpawn
            );
            list.Add(
                objectsToSpawn2
            );
            list.Add(
                objectsToSpawn3
            );
            gun.objectsToSpawn = list.ToArray();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//
        }

        protected override string GetTitle()
        {
            return "Barrage";
        }
        protected override string GetDescription()
        {
            return "Salvo of homing, exploding bullets";
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
                    stat = "Missle Salvo",
                    amount = "Yes",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Speed",
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "DMG",
                    amount = "-20%",
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
                    positive = true,
                    stat = "Spread",
                    amount = "+35%",
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
