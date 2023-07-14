using Conquest.Items.Weapons.Melee;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Conquest.Assets.Systems
{
    public class ShimmerRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Gladius)
                  .AddCustomShimmerResult(ModContent.ItemType<EmperorSword>())
                  .AddCondition(Condition.DownedEowOrBoc)
                  .AddCondition(Language.GetOrRegister("Shimmered"), () => NPC.downedBoss2)
                  .Register();
            Recipe recipe2 = Recipe.Create(ItemID.Muramasa)
                 .AddCustomShimmerResult(ModContent.ItemType<Chikage>())
                 .AddCondition(Language.GetOrRegister("Shimmered"), () => NPC.downedBoss3)
                 .AddCondition(Condition.DownedSkeletron)
                 .Register();

        }
    }
    public class GladiusGlobal : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.Gladius;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new(Mod, "", "Can be shimmered"));
        }
    }
    public class MuramasaGlobal : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.Muramasa;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new(Mod, "", "Can be shimmered"));
        }
    }

}
