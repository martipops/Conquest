using SubworldLibrary;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Point16 = Terraria.DataStructures.Point16;
using Terraria.DataStructures;
using StructureHelper;

namespace Conquest.Subworlds
{
    public class AntlionArena : Subworld
    {
        public override int Width => 362;
        public override int Height => 158;
        public override bool NormalUpdates => false;
        public override bool ShouldSave => true;
        public override bool NoPlayerSaving => false;
        public override void CopyMainWorldData()
        {
            SubworldSystem.CopyWorldData(nameof(Main.expertMode), Main.expertMode);
            SubworldSystem.CopyWorldData(nameof(Main.masterMode), Main.masterMode);
        }
        public override List<GenPass> Tasks => new List<GenPass>()
        {
               new PassLegacy ("Generating thing", (progress, _) =>
               {
                    progress.Message = "Generating Antlion Arena";
                    Main.spawnTileX = 250;
                    Main.spawnTileY = 109;
                    Main.rockLayer = Main.maxTilesY - 350;
                    int x = 0;
                    int y = 0;
                    Point16 point = new Point16(x, y);
                    Generator.GenerateStructure("Structures/AntlionArena", point, Mod);
                },90f),
        };
        public override void OnEnter()
        {
              SubworldSystem.hideUnderworld = true;
              Player player = Main.LocalPlayer;
             
        }
        public override void OnExit()
        {
            base.OnExit();
        }

    }

}
