using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using ClassesManagerReborn;
using YCDRCards.Cards.Skybound;

namespace YCDRCards.Cards.Skybound
{
    class Skyboundclass : ClassHandler
    {
        internal static string name = "Skybound";
        public override IEnumerator Init()
        {
            //("Regestering: " + name);
            while (!(SkyboundGate.Card && Tailwind.Card && BombRun.Card && Napalm.Card)) yield return null;
            ClassesRegistry.Register(SkyboundGate.Card, CardType.Entry);
            ClassesRegistry.Register(Tailwind.Card, CardType.Card, SkyboundGate.Card);
            ClassesRegistry.Register(BombRun.Card, CardType.Card, SkyboundGate.Card);
            ClassesRegistry.Register(Napalm.Card, CardType.Card, SkyboundGate.Card);
        }
        public override IEnumerator PostInit()
        {
            
            yield break;
        }
    };
}
