using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using YCDRCards.Cards;
using YCDRCards.Cards.Chaos;
using YCDRCards.Cards.Blocker;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModdingUtils;
using ModdingUtils.Extensions;
using Jotunn.Utils;
using System.Linq;
using System.Collections;
using System;
using System.Collections.ObjectModel;
using WillsWackyManagers.Utils;
using ModdingUtils.GameModes;
using YCDRCards.Cards.Doped;

namespace YCDRCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.classes.manager.reborn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willuwontu.rounds.managers", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class YCDRCards : BaseUnityPlugin
    {
        private const string ModId = "com.YCDR.rounds.YCDRCards";
        private const string ModName = "YCDRCards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "YCDR";
        public static YCDRCards instance { get; private set; }

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            instance = this;

            //Base cards
            CustomCard.BuildCard<Disengage>();
            CustomCard.BuildCard<StrongGun>();
            CustomCard.BuildCard<ItDies>();
            CustomCard.BuildCard<ItFollows>();
            CustomCard.BuildCard<ItLives>();
            CustomCard.BuildCard<Yeet>();
            CustomCard.BuildCard<Crack>();
            CustomCard.BuildCard<SmoothMovement>();
            CustomCard.BuildCard<TractorBeam>();
            CustomCard.BuildCard<LittleBoi>();
            CustomCard.BuildCard<Floater>();
            CustomCard.BuildCard<Metabolise>();
            CustomCard.BuildCard<Pinpoint>();
            CustomCard.BuildCard<Defensive>();
            CustomCard.BuildCard<Bork>();
            CustomCard.BuildCard<Monke>();
            CustomCard.BuildCard<BigBoi>();
            CustomCard.BuildCard<Beachball>();
            CustomCard.BuildCard<Snipe>();
            CustomCard.BuildCard<CoverFire>();
            CustomCard.BuildCard<PierceThrough>();
            CustomCard.BuildCard<Digger>();
            CustomCard.BuildCard<GuardianAngel>();
            CustomCard.BuildCard<Cockroach>();
            CustomCard.BuildCard<Barrage>();
            CustomCard.BuildCard<Reset>();
            CustomCard.BuildCard<MonsterSlayer>();
            CustomCard.BuildCard<Longshot>();
            CustomCard.BuildCard<Personal>();
            //uses effect threshholds
            CustomCard.BuildCard<Beserk>();
            CustomCard.BuildCard<Shrink>();

            //has monobehaviours
            CustomCard.BuildCard<Parry>();
            CustomCard.BuildCard<Sprint>();
            CustomCard.BuildCard<Lifeblood>();

            //Chaos Class
            CustomCard.BuildCard<ChaosTime>((card) => ChaosTime.Card = card);
            CustomCard.BuildCard<Seeker>((card) => Seeker.Card = card);
            CustomCard.BuildCard<MustardGas>((card) => MustardGas.Card = card);
            CustomCard.BuildCard<MoreBalls>((card) => MoreBalls.Card = card);
            //monobehaviours
            CustomCard.BuildCard<ChaosBalls>((card) => ChaosBalls.Card = card);

            //Blockers Class
            CustomCard.BuildCard<Blocker>((card) => Blocker.Card = card);
            CustomCard.BuildCard<Warden>((card) => Warden.Card = card);
            CustomCard.BuildCard<Mending>((card) => Mending.Card = card);
            //monobehaviours
            CustomCard.BuildCard<BodyFat>((card) => BodyFat.Card = card);

            //Doping Class
            CustomCard.BuildCard<DopedGate>((card) => DopedGate.Card = card);
            CustomCard.BuildCard<Steroids>((card) => Steroids.Card = card);
            CustomCard.BuildCard<Junkie>((card) => Junkie.Card = card);
            CustomCard.BuildCard<Juiced>((card) => Juiced.Card = card);
            CustomCard.BuildCard<OlympianAthlete>((card) => OlympianAthlete.Card = card);
        }
    }
}
