using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Conquest;
using Conquest;
using Mono.Cecil;
using System.Security.Cryptography.X509Certificates;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Physics;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModNPC;




namespace Conquest.NPCs.Apep
{
    [AutoloadBossHead]
	public class ApepFX : GlobalNPC
	{
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
			if (NPC.CountNPCS(ModContent.NPCType<Apep>()) > 0)
			{
				spawnRate = (int)(9999);
				maxSpawns = (int)(maxSpawns * 9999999);
			}
		}
	}
    public class Apep : ModNPC
    {
		static int head = NPCHeadLoader.GetBossHeadSlot($"{nameof(Conquest)}/NPCs/Apep/Apepicon");
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if ((SpawnCondition.Underworld.Chance > 0) && Main.zenithWorld && (NPC.CountNPCS(ModContent.NPCType<Apep>()) == 0)) return 0.001f;
			else return 0f;
			
		}
		public override void ModifyHitPlayer(Player target,ref Player.HurtModifiers modifiers)	
		{
			target.KillMe(PlayerDeathReason.ByCustomReason(target.name+" was consumed by the maw of Apep."),9999999,0,true);
		}
		SoundStyle Terror = new SoundStyle($"{nameof(Conquest)}/NPCs/Apep/Scream")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 10,
        };
		SoundStyle Charge = new SoundStyle($"{nameof(Conquest)}/NPCs/Apep/Charge")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 10,
        };
		public override bool CanHitNPC (NPC target) => true;
		public override void SetDefaults()
		{
			BossHeadSlot(ref head);
			int width = 16; int height = 128;
			NPC.Size = new Vector2(width, height);
			NPC.aiStyle = NPCAIStyleID.Worm;
            NPC.damage = 9999999;
            NPC.defense = 500;
            NPC.lifeMax = 9999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
			NPC.dontTakeDamage = false;

            NPC.HitSound = Charge;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;
            NPC.npcSlots = 0f;
			NPC.dontCountMe = true;
			NPC.boss = true;
		}
		public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (player.dead)
			{
				//if (NPC.timeLeft > 30000) NPC.timeLeft = 30000;
				NPC.timeLeft = 30000;
				NPC.boss = false;
				//NPC.life = 0;
				NPC.velocity.Y += 2;
			}
            else
			{
				if (NPC.target < 0 || NPC.target == 250 || player.dead) NPC.TargetClosest(true);
				NPC.boss = true;
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					if (NPC.ai[0] == 0f)
					{
						NPC.ai[3] = NPC.whoAmI;
						NPC.realLife = NPC.whoAmI;
						int num8 = NPC.whoAmI;
						SoundEngine.PlaySound(Terror, NPC.position);
						for (int l = 0; l < 1024; l++)
						{
							int num9 = ModContent.NPCType<ApepBodyFess>();
							switch (l%13)
							{
								case 0:
									num9 = ModContent.NPCType<ApepBodyBast>();
									break;
								case 3:
									num9 = ModContent.NPCType<ApepBodyRan>();
									break;
								case 6:
									num9 = ModContent.NPCType<ApepBodyGaunt>();
									break;
								case 9:
									num9 = ModContent.NPCType<ApepBodyFess>();
									break;
								case 11:
									num9 = ModContent.NPCType<ApepBodyStrom>();
									break;
								default:
									num9 = ModContent.NPCType<ApepBodyRom>();
									break;
							}
							int num7 = NPC.NewNPC(NPC.GetSource_FromAI(), (int)(NPC.position.X + NPC.width / 2), (int)(NPC.position.Y + NPC.height), num9, NPC.whoAmI);
							Main.npc[num7].ai[3] = NPC.whoAmI;
							Main.npc[num7].realLife = NPC.whoAmI;
							Main.npc[num7].ai[1] = num8;
							Main.npc[num7].CopyInteractions(Main.npc[num8]);
							Main.npc[num8].ai[0] = num7;
							NetMessage.SendData(23, -1, -1, null, num7);
							num8 = num7;
						}
					}
				}

				int num107 = (int)(NPC.position.X / 16f) - 1;
				int num108 = (int)((NPC.position.X + NPC.width) / 16f) + 2;
				int num109 = (int)(NPC.position.Y / 16f) - 1;
				int num110 = (int)((NPC.position.Y + NPC.height) / 16f) + 2;

				if (num107 < 0) num107 = 0;
				if (num108 > Main.maxTilesX) num108 = Main.maxTilesX;
				if (num109 < 0) num109 = 0;
				if (num110 > Main.maxTilesY) num110 = Main.maxTilesY;
				if (NPC.velocity.X < 0f) NPC.spriteDirection = 1;
				if (NPC.velocity.X > 0f) NPC.spriteDirection = -1;

				float num115 = 16f;
				float num116 = 0.4f;

				Vector2 vector14 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
				float num118 = Main.rand.Next(-500, 501) + player.position.X + (player.width / 2);
				float num119 = Main.rand.Next(-500, 501) + player.position.Y + (player.height / 2);
				num118 = ((int)(num118 / 16f) * 16);
				num119 = ((int)(num119 / 16f) * 16);
				vector14.X = ((int)(vector14.X / 16f) * 16);
				vector14.Y = ((int)(vector14.Y / 16f) * 16);
				num118 -= vector14.X;
				num119 -= vector14.Y;
				float num120 = (float)Math.Sqrt((num118 * num118 + num119 * num119));

				float num123 = Math.Abs(num118);
				float num124 = Math.Abs(num119);
				float num125 = num115 / num120;
				num118 *= num125;
				num119 *= num125;

				bool flag14 = false;
				if (((NPC.velocity.X > 0f && num118 < 0f) || (NPC.velocity.X < 0f && num118 > 0f) || (NPC.velocity.Y > 0f && num119 < 0f) || (NPC.velocity.Y < 0f && num119 > 0f)) && Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) > num116 / 2f && num120 < 300f)
				{
					flag14 = true;
					if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num115)NPC.velocity *= 1.1f;
				}
				if (NPC.position.Y > player.position.Y || ((player.position.Y/16) < Main.maxTilesY - 190) || player.dead)
				{
					flag14 = true;
					if (Math.Abs(NPC.velocity.X) < num115 / 2f)
					{
						if (NPC.velocity.X == 0f) NPC.velocity.X = NPC.velocity.X - NPC.direction;
						NPC.velocity.X = NPC.velocity.X * 1.1f;
					}
					else
					{
						if (NPC.velocity.Y > -num115) NPC.velocity.Y = NPC.velocity.Y - num116;
					}
				}
				if (!flag14)
				{
					if ((NPC.velocity.X > 0f && num118 > 0f) || (NPC.velocity.X < 0f && num118 < 0f) || (NPC.velocity.Y > 0f && num119 > 0f) || (NPC.velocity.Y < 0f && num119 < 0f))
					{
						if (NPC.velocity.X < num118) NPC.velocity.X = NPC.velocity.X + num116;
						else
						{
							if (NPC.velocity.X > num118) NPC.velocity.X = NPC.velocity.X - num116;
						}
						if (NPC.velocity.Y < num119) NPC.velocity.Y = NPC.velocity.Y + num116;
						else
						{
							if (NPC.velocity.Y > num119) NPC.velocity.Y = NPC.velocity.Y - num116;
						}
						if (Math.Abs(num119) < num115 * 0.2 && ((NPC.velocity.X > 0f && num118 < 0f) || (NPC.velocity.X < 0f && num118 > 0f)))
						{
							if (NPC.velocity.Y > 0f) NPC.velocity.Y = NPC.velocity.Y + num116 * 2f;
							else NPC.velocity.Y = NPC.velocity.Y - num116 * 2f;
						}
						if (Math.Abs(num118) < num115 * 0.2 && ((NPC.velocity.Y > 0f && num119 < 0f) || (NPC.velocity.Y < 0f && num119 > 0f)))
						{
							if (NPC.velocity.X > 0f) NPC.velocity.X = NPC.velocity.X + num116 * 2f;
							else NPC.velocity.X = NPC.velocity.X - num116 * 2f;
						}
					}
					else
					{
						if (num123 > num124)
						{
							if (NPC.velocity.X < num118) NPC.velocity.X = NPC.velocity.X + num116 * 1.1f;
							else
							{
								if (NPC.velocity.X > num118) NPC.velocity.X = NPC.velocity.X - num116 * 1.1f;
							}
							if ((Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y)) < num115 * 0.5)
							{
								if (NPC.velocity.Y > 0f) NPC.velocity.Y = NPC.velocity.Y + num116;
								else NPC.velocity.Y = NPC.velocity.Y - num116;
							}
						}
						else
						{
							if (NPC.velocity.Y < num119) NPC.velocity.Y = NPC.velocity.Y + num116 * 1.1f;
							else
							{
								if (NPC.velocity.Y > num119) NPC.velocity.Y = NPC.velocity.Y - num116 * 1.1f;
							}
							if ((Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y)) < num115 * 0.5)
							{
								if (NPC.velocity.X > 0f) NPC.velocity.X = NPC.velocity.X + num116;
								else NPC.velocity.X = NPC.velocity.X - num116;
							}
						}
					}
				}
			}
            NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) + 1.57f;
        }
	}
	public class ApepBodyBast : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 50; int height = 86;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
	public class ApepBodyRan : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 50; int height = 86;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
	public class ApepBodyGaunt : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 16; int height = 44;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
	public class ApepBodyFess : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 16; int height = 44;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
	public class ApepBodyStrom : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 16; int height = 36;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
            NPC.noGravity = true;
            NPC.noTileCollide = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
	public class ApepBodyRom : ModNPC
    {
		public override bool CheckActive() => false;
		public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
		{
			boundingBox = new Rectangle(0,0,0,0);
		}
        public override void SetStaticDefaults()
        {

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Hide = true
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);

        }
        public override void SetDefaults()
        {
            int width = 14; int height = 24;
            NPC.Size = new Vector2(width, height);

            NPC.aiStyle = NPCAIStyleID.Worm;

            NPC.damage = 500;
            NPC.defense = 9999999;
            NPC.lifeMax = 9999999;
			//NPC.immortal = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
			//NPC.dontTakeDamage = true;

            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath8;

            NPC.knockBackResist = 0.0f;

            NPC.dontCountMe = true;
			NPC.boss = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => new bool?(false);

        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }
            if (NPC.position.X > Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = 1;
            if (NPC.position.X < Main.npc[(int)NPC.ai[1]].position.X) NPC.spriteDirection = -1;
        }
    }  
}
		