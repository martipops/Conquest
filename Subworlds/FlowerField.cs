using SubworldLibrary;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Point16 = Terraria.DataStructures.Point16;
using StructureHelper;

namespace Conquest.Subworlds
{
    public class FlowerField : Subworld
    {
        public override int Width => 600;
        public override int Height => 500;
        public override bool NormalUpdates => false;
        public override bool ShouldSave => false;
        public override bool NoPlayerSaving => false;

        public override List<GenPass> Tasks => new List<GenPass>()
        {
               new PassLegacy ("Generating thing", (progress, _) =>
                {
                    progress.Message = "Generating Flower Field";
                    Main.spawnTileX = 230;
                    Main.spawnTileY = 241;
                     Main.worldSurface = 399;
                     int x = 50;
                     int y = 160;
                     Point16 point = new Point16(x, y);
                    Generator.GenerateStructure("Structures/FlowerField", point, Conquest.Instance, false);
                },90f),

        };
        public override void OnEnter()
        {
            SubworldSystem.hideUnderworld = true;

        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }

}
