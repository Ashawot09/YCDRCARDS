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
using ClassesManagerReborn.Util;
using YCDRCards.Cards.Chaos;

namespace YCDRCards.Cards
{
    class ChaosBalls : CustomCard
    {
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
//
            cardInfo.allowMultiple = false;
            gun.reflects = 50;
            gun.damage = 0.4f;
            gun.knockback = 0.5f;
            gun.gravity = 1.15f;
            gun.projectielSimulatonSpeed = 0.6f;
            gun.projectileSpeed = 1.2f;
            gun.projectileSize = 2.5f;
            gun.reloadTime = 1.3f;

            //unbulleted bullets 
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
//

            player.gameObject.AddComponent<OneBulletMono>();

            player.gameObject.AddComponent<AlwaysBlockableMono>();

            gun.projectileColor = Color.white;

            ObjectsToSpawn objectsToSpawn = ((GameObject)Resources.Load("0 cards/Mayhem")).GetComponent<Gun>().objectsToSpawn[0];
            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList();
            list.Add(
                objectsToSpawn
            );
            gun.objectsToSpawn = list.ToArray();

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
//
            if (player.transform.gameObject.GetComponent<OneBulletMono>() != null)
            {
                Destroy(player.transform.gameObject.GetComponent<OneBulletMono>());
            }
            if (player.transform.gameObject.GetComponent<AlwaysBlockableMono>() != null)
            {
                Destroy(player.transform.gameObject.GetComponent<AlwaysBlockableMono>());
            }
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = ChaosClass.name;
        }

        protected override string GetTitle()
        {
            return "Chaos Balls";   
        }
        protected override string GetDescription()
        {
            return "Pong but actually fun (Bullets can always be blocked)";
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
                    stat = "Bounces",
                    amount = "50",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "= 1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "DMG",
                    amount = "-60%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Time",
                    amount = "+30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return "YCDR";
        }
    }
}
