using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using ClassesManagerReborn;

namespace YCDRCards.Cards.Chaos
{
    class ChaosClass : ClassHandler
    {
        internal static string name = "Chaos";
        public override IEnumerator Init()
        {
            //("Regestering: " + name);
            while (!(ChaosTime.Card && Seeker.Card && MustardGas.Card && ChaosBalls.Card && MoreBalls.Card)) yield return null;
            ClassesRegistry.Register(ChaosTime.Card, CardType.Entry);
            ClassesRegistry.Register(ChaosBalls.Card, CardType.SubClass, ChaosTime.Card);
                ClassesRegistry.Register(MoreBalls.Card, CardType.Card, ChaosBalls.Card);
            ClassesRegistry.Register(Seeker.Card, CardType.Card, ChaosTime.Card);
            ClassesRegistry.Register(MustardGas.Card, CardType.Card, ChaosTime.Card);
            
        }
        public override IEnumerator PostInit()
        {
            
            yield break;
        }
    };
}
