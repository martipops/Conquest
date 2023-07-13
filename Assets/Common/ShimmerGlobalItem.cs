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
                  .AddCondition(Condition.DownedBrainOfCthulhu)
                  .AddCondition(Language.GetOrRegister("Shimmered"), () => NPC.downedBoss2)
                  .Register();
            Recipe recipe2 = Recipe.Create(ItemID.Gladius)
                 .AddCustomShimmerResult(ModContent.ItemType<EmperorSword>())
                 .AddCondition(Language.GetOrRegister("Shimmered"), () => NPC.downedBoss2)
                 .AddCondition(Condition.DownedEaterOfWorlds)
                 .Register();

        }
    }
    public class GladiusGlobal : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.Gladius;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Here we add a tooltip to the gel to let the player know what will happen
            tooltips.Add(new(Mod, "", "Can be shimmered"));
        }
    }
}
