﻿using System;
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
    class Steroids : CustomCard
    {
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, global::CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{YCDRCards.ModInitials}][Card] {GetTitle()} has been setup.");
            statModifiers.health = 1.07f;
            statModifiers.movementSpeed = 1.07f;
            statModifiers.jump = 1.07f;
            statModifiers.sizeMultiplier = 0.993f;
            block.cdMultiplier = 0.93f;
            gun.reloadTime = 0.93f;
            gun.gravity = 0.93f;
            gun.projectileSpeed = 1.07f;
            gun.projectielSimulatonSpeed = 1.07f;
            gun.damage = 1.07f;
            gun.attackSpeed = 0.93f;
            gun.knockback = 1.07f;
            gun.destroyBulletAfter = 1.07f;

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{YCDRCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");

            gunAmmo.maxAmmo += 1;
            characterStats.lifeSteal += 0.07f;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, global::CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{YCDRCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }

        protected override string GetTitle()
        {
            return "Steroids";
        }
        protected override string GetDescription()
        {
            return "Increase posistive stats and reduce negatives stats";
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
                    stat = "Positive stats",
                    amount = "+7%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Negative stats",
                    amount = "-7%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+1",
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
