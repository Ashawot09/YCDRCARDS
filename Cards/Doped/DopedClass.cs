using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using ClassesManagerReborn;

namespace YCDRCards.Cards.Doped
{
    class DopedClass : ClassHandler
    {
        internal static string name = "Doping";
        public override IEnumerator Init()
        {
            //("Regestering: " + name);
            while (!(DopedGate.Card && Steroids.Card && Junkie.Card && Juiced.Card && OlympianAthlete.Card)) yield return null;
            ClassesRegistry.Register(DopedGate.Card, CardType.Entry);
            ClassesRegistry.Register(Steroids.Card, CardType.Card, DopedGate.Card);
            ClassesRegistry.Register(Junkie.Card, CardType.Card, DopedGate.Card);
            ClassesRegistry.Register(Juiced.Card, CardType.Card, DopedGate.Card);
            ClassesRegistry.Register(OlympianAthlete.Card, CardType.Card, DopedGate.Card);
        }
        public override IEnumerator PostInit()
        {
            
            yield break;
        }
    };
}
