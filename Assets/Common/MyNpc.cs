using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Conquest.Assets.Common
{
    public class MyNpc : GlobalNPC
    {
        public bool Electrified = false;
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            Electrified = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Electrified)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 70;
                if (damage < 10)
                {
                    damage = 10;
                }
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (modPlayer.war)
            {
                spawnRate = (int)(spawnRate * 0.01);
                maxSpawns = (int)(maxSpawns * 3);
            }
        }
        public override void OnKill(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (modPlayer.Glory)
            {
                if (Main.rand.NextBool(150))
                {
                    Item.NewItem(npc.GetSource_Death(), npc.position, new Vector2(npc.width, npc.height), ItemID.GoldCoin);
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Electrified)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 226, npc.velocity.X * 0f, npc.velocity.Y * 0f, 100, default(Color), .4f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
