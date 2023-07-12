using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace Conquest.Assets.Common
{
    internal class MinionCrit : ModSystem
    {
        public override void PostSetupContent()
        {
            typeof(DamageClass).GetProperty("Summon", BindingFlags.Static | BindingFlags.Public)?.SetValue(null, new BetterSummonDamageClass());
            typeof(DamageClass).GetProperty("SummonMeleeSpeed", BindingFlags.Static | BindingFlags.Public)?.SetValue(null, new BetterSummonMeleeSpeedDamageClass());
        }

        private class BetterSummonDamageClass : VanillaDamageClass
        {
            protected override string LangKey => "LegacyTooltip.53";
            public override bool ShowStatTooltipLine(Player player, string lineName) => lineName != "Speed";
        }

        private class BetterSummonMeleeSpeedDamageClass : VanillaDamageClass
        {
            protected override string LangKey => "LegacyTooltip.53";

            public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
            {
                if (damageClass == Melee)
                {
                    return new StatInheritanceData(attackSpeedInheritance: 1f);
                }

                if (damageClass == Generic || damageClass == Summon)
                {
                    return StatInheritanceData.Full;
                }

                return StatInheritanceData.None;
            }

            public override bool GetEffectInheritance(DamageClass damageClass) => damageClass == Summon;
        }
    }
}
