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
using CR.MonoBehaviors;

namespace YCDRCards.Cards
{
    class ToxicMines : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            gun.projectielSimulatonSpeed = 0.2f;
            gun.attackSpeedMultiplier = 1.25f;
            gun.damage = 1.6f;
            gun.projectileColor = Color.green;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            List<ObjectsToSpawn> list = Enumerable.ToList<ObjectsToSpawn>(gun.objectsToSpawn);
            list.Add(new ObjectsToSpawn
            {
                AddToProjectile = new GameObject("ToxicMines", new Type[]
                {
                    typeof(ToxicMines_Mono)
                })
            });
            gun.objectsToSpawn = list.ToArray();


            List<ObjectsToSpawn> list2 = gun.objectsToSpawn.ToList();
            ObjectsToSpawn objectsToSpawn = ((GameObject)Resources.Load("0 cards/Toxic cloud")).GetComponent<Gun>().objectsToSpawn[0];
            list2.Add(
                objectsToSpawn
            );
            gun.objectsToSpawn = list2.ToArray();

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {

        }

        protected override string GetTitle()
        {
            return "Toxic Mines";
        }
        protected override string GetDescription()
        {
            return "Slow toxic cloud mines that deal their damage over 4 seconds";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "+60%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Projectile speed",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },  
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Attack speed",
                    amount = "+25%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
