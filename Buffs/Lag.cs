using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

// auth: Goose
// A debuff that lags any entity that it affects.

namespace Conquest.Buffs;

public class Lag : ModBuff
{
    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<LagPlayerTracker>().lagging = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.GetGlobalNPC<LagNPCTracker>().lagging = true;
    }
}

public class LagNPCTracker : GlobalNPC
{
    public override bool InstancePerEntity => true;
    public bool lagging = false;
    List<Vector2> oldPositions = new List<Vector2>();

    public override void AI(NPC npc)
    {
        oldPositions.Insert(0, npc.position);
        while (oldPositions.Count > 60)
        {
            oldPositions.RemoveAt(oldPositions.Count - 1);
        }
        if (lagging)
        {
            if (Main.rand.NextBool(40) && !npc.boss)
            {
                npc.position = oldPositions[Main.rand.Next(oldPositions.Count)];
            }
            if (Main.rand.NextBool(40) && !npc.boss)
            {
                npc.velocity = Vector2.Lerp(npc.velocity, Vector2.Zero, MathHelper.Clamp(npc.knockBackResist, 0, 1));
            }
            foreach (Projectile p in Main.projectile)
            {
                if (p.active && p.Distance(npc.position) < 100 && Main.rand.NextBool(40))
                {
                    p.position += Main.rand.NextVector2Circular(40, 40);
                }
            }
        }
    }

    public override void ResetEffects(NPC npc)
    {
        lagging = false;
    }
}

public class LagPlayerTracker : ModPlayer
{
    List<Vector2> oldPlayerPositions = new List<Vector2>();
    public bool lagging = false;

    public override void PreUpdateMovement()
    {
        oldPlayerPositions.Insert(0, Player.position);
        while (oldPlayerPositions.Count > 60)
        {
            oldPlayerPositions.RemoveAt(oldPlayerPositions.Count - 1);
        }
        if (lagging)
        {
            if (Main.rand.NextBool(40))
            {
                Player.position = oldPlayerPositions[Main.rand.Next(oldPlayerPositions.Count)];
            }
            if (Main.rand.NextBool(40))
            {
                Player.velocity = Vector2.Zero;
            }
            foreach (Projectile p in Main.projectile)
            {
                if (p.active && p.Distance(Player.position) < 100 && Main.rand.NextBool(40))
                {
                    p.position += Main.rand.NextVector2Circular(40, 40);
                }
            }
        }
    }

    public override void ResetEffects()
    {
        lagging = false;
    }
}
