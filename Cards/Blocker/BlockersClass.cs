using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using ClassesManagerReborn;

namespace YCDRCards.Cards.Blocker
{
    class BlockersClass : ClassHandler
    {
        internal static string name = "Blockers";
        public override IEnumerator Init()
        {
            //("Regestering: " + name);
            while (!(Blocker.Card && Warden.Card && BodyFat.Card && Mending.Card && Karma.Card)) yield return null;
            ClassesRegistry.Register(Blocker.Card, CardType.Entry);
            ClassesRegistry.Register(Warden.Card, CardType.Card, Blocker.Card);
            ClassesRegistry.Register(BodyFat.Card, CardType.Card, Blocker.Card);
            ClassesRegistry.Register(Mending.Card, CardType.Card, Blocker.Card);
            ClassesRegistry.Register(Karma.Card, CardType.Card, Blocker.Card);
        }
        public override IEnumerator PostInit()
        {

            yield break;
        }
    };
}
