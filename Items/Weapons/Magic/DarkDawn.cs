using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Conquest.Projectiles.DarkDawnProjectiles;

namespace Conquest.Items.Weapons.Magic {
    public class DarkDawn : ModItem {
        private SoundStyle sunIsReady = new SoundStyle("Conquest/Assets/Sounds/SunIsReady");
        private SoundStyle hahaha = new SoundStyle("Conquest/Assets/Sounds/Hahaha");
        private bool sunIsReadyPlayed;
        public static LocalizedText DarkDawnDamage { get; private set; } // localisation stuff for .hjson file prop
        public static LocalizedText DarkDawnMana { get; private set; }
        public static LocalizedText DarkDawnDeathMessage { get; private set; }
        public static int sunEnergy; // parameter that stores number of energy needed to use the Falling sun
        private static int useTimeDelay; // useTime, but custom
        public static bool isCasting; // statement for zoom feature in ModPlayer below 
        public static float infT; // timer for inf function moving
        private int preDrawT; // timer for PreDrawInWorld()
        private Color dustColor; // inf function color
        public static float dustSize; // inf function size
        private int animeFrame = 4; // this is number of the item frames
        private int frameY; // this is for PreDrawInWorld below
        private float shaderLerp; // shader's "jumping" parameter
        private float shaderDistIntensity; // intensity of the distortion
        private float shaderFBIntensity; // intensity of the flashlight
        private float  localShaderFBlerp;
        private float intensityFBfix;
        private float shaderSqt; // squared components value
        private double storedTime;
        private bool timeIsStored;
        public static float castDelay; // how many time need to be gone, before using this item after holding a mouse left.

        public override void SetStaticDefaults() {
            DarkDawnDeathMessage = this.GetLocalization(nameof(DarkDawnDeathMessage));
            DarkDawnDamage = this.GetLocalization(nameof(DarkDawnDamage)); // localisation stuff for .hjson file prop
            Item.ResearchUnlockCount = 1;
        }
        Item DarkDawnItem; // localisation stuff for .hjson file prop
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			foreach (TooltipLine line2 in tooltips) {
                TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Damage");
                TooltipLine mana = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "UseMana");
                
                if (line != null) {
                    line.Text = Language.GetTextValue("[c/ff6a00:∞ magic power]");
                }
                if (mana != null) {
                    mana.Text = Language.GetTextValue("Uses ∞ mana or life");
                }
			}
        }
        public override void SetDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, animeFrame));
            Item.width = 40;
            Item.height = 52;
            Item.value = Item.sellPrice(gold: 10);
            Item.noMelee = true;
            Item.rare = ItemRarityID.Master;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.noUseGraphic = true;
            Item.autoReuse = true;
            Item.damage = 48;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ProjectileID.BlackCat;
            Item.shootSpeed = 15f;
        }
        public static float GetBrightness(Vector2 worldPosition) {
            var tileCoords = worldPosition.ToTileCoordinates();
            return Lighting.Brightness(tileCoords.X, tileCoords.Y);
        }
        public override void HoldItem(Player player) {

            shaderSqt = shaderLerp * shaderLerp;
            dustColor = new Color(255, 106, 0);

            // shader lerps for waving/winking effects
            if (shaderLerp < 1f) shaderLerp += 0.04f;
            else shaderLerp = 0f;

            if (localShaderFBlerp < 1f) localShaderFBlerp += 0.04f;
            else localShaderFBlerp = 0.5f;

            if (Main.mouseLeft && !player.dead) {

                castDelay++;
                if(castDelay > 10) isCasting = true;

                if(isCasting) {
                    if (!timeIsStored) {
                        storedTime = Main.time;
                        timeIsStored = true;
                    }
                    if (timeIsStored) Main.time = 1;

                    useTimeDelay++;
                    
                    if (useTimeDelay >= 5) {

                        player.statMana -= 10;
                        useTimeDelay = 0;
                    }
                    if (player.statMana <= 0) player.statMana = 0;

                    //calculating mana eating and consequences
                    if (player.statMana < 1) {

                        player.statLife -= 1;
                        if (player.statLife <= 0) {

                            player.KillMe(PlayerDeathReason.ByCustomReason(DarkDawnDeathMessage.Format()), 9999, 0);
                            SoundEngine.PlaySound(hahaha);
                        }
                    }
                    // shaders intensity
                    shaderDistIntensity = MathHelper.Lerp(15f, 40f, shaderSqt / (2.0f * (shaderSqt - shaderLerp) + 1.0f));

                    if (!Filters.Scene["Distortion"].IsActive()) {

                        Filters.Scene.Activate("Distortion");
                        Filters.Scene.Activate("FlashLight");
                    }
                    Filters.Scene["Distortion"].GetShader().UseIntensity(shaderDistIntensity);
                    Filters.Scene["FlashLight"].GetShader().UseIntensity(20f + localShaderFBlerp);

                    // spawning projectiles
                    Projectile.NewProjectile(
                        Entity.GetSource_FromThis(),
                        player.Center, Vector2.Zero,
                        ModContent.ProjectileType<DarkDawnProjEclipseFire>(),
                        0, 0, player.whoAmI
                    );
                    if (sunEnergy >= 1200) {

                        if (Main.mouseRight) {

                            sunEnergy = 0;
                            Projectile.NewProjectile(
                                Entity.GetSource_FromThis(),
                                player.Center + new Vector2(0, -1000f), Vector2.Zero,
                                ModContent.ProjectileType<DarkDawnProjFuckingSun>(),
                                100, 0, player.whoAmI
                            );
                        }
                        if (!sunIsReadyPlayed) {

                            for (int k = 0; k < 100; k++) {

                                Vector2 readyPos = Main.rand.NextVector2CircularEdge(player.width / 2, player.width / 2);
                                Dust readyDust = Dust.NewDustPerfect(player.Center + readyPos, DustID.RainbowMk2, readyPos, 255, dustColor, 2f);
                                readyDust.noGravity = true;
                                readyDust.fadeIn = 0f;
                            }
                            SoundEngine.PlaySound(sunIsReady);
                            sunIsReadyPlayed = true;
                        }
                    }
                    else sunIsReadyPlayed = false;
                } 
            }
            else { // !Main.mouseLeft

                castDelay = 0;
                isCasting = false;

                if (timeIsStored) {

                    Main.time = storedTime;
                    timeIsStored = false;
                }

                //disabling a shaders
                if (Filters.Scene["Distortion"].IsActive()) {

                    Filters.Scene.Deactivate("Distortion");
                    Filters.Scene.Deactivate("FlashLight");
                }
                // drawing a lissajous inf symbol    
                float factor = 2 / (3 - (float)Math.Cos(2 * infT)); // to make lissajous more infinity like 
                float rot = (Main.MouseWorld - player.Center).ToRotation();
                Vector2 infVelocity = new Vector2(20 * factor * (float)Math.Cos(infT), 20 * factor * (float)Math.Sin(2 * infT) / 2);
                Dust infDust = Dust.NewDustPerfect(
                    player.Center + new Vector2(0, -100f) - infVelocity, // position
                    DustID.RainbowMk2, // type
                    player.velocity, // velocity
                    255, // alpha
                    dustColor, // color
                    dustSize // scale
                );
                infDust.noGravity = true;
                Dust inf2Dust = Dust.NewDustPerfect(
                    player.Center + new Vector2(0, -100f) + infVelocity, // position
                    DustID.RainbowMk2, // type
                    player.velocity, // velocity
                    255, // alpha
                    dustColor, // color
                    dustSize // scale
                );
                inf2Dust.noGravity = true;
            }
        }
       
   
        public override bool AltFunctionUse(Player player) {
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            return false;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) {
            
            // this for animation work when in world (because it doesn't works with out it somehow)
            Texture2D texture = TextureAssets.Item[Item.type].Value;
            preDrawT++;
            if (preDrawT > 6) {
                if (frameY == texture.Height - texture.Height / animeFrame)
                    frameY = 0;
                else {
                    frameY += texture.Height / animeFrame;
                }
                preDrawT = 0;
            }
            Rectangle frame = new Rectangle(0, frameY, texture.Width, texture.Height / animeFrame);
            Vector2 frameOrigin = frame.Size() / 2f;
			Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
			Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset + new Vector2(0, 10f);
            spriteBatch.Draw(texture, drawPos, frame, lightColor, rotation, frameOrigin, scale * 0.7f, SpriteEffects.None, 0);
            return false;
        }
    }
    public class playerStuff : ModPlayer {
        public static bool cameraShaking; // this value says when needed to shake a camera. uses in projectile files
        private float shakingValue; // 1 or 0, dont touch it unless you want to break something :d
        private float shakingForce = 5f; // how strong will be camera shacking
        private static float lerpValue;
        private float sqt;
        private float cosValue;
        private int delay; // delay before unzoom

        public override void PostUpdate() {

            if(Main.LocalPlayer.HeldItem.ModItem is not DarkDawn || Main.LocalPlayer.dead || !DarkDawn.isCasting) {
                if(Main.mouseLeft && FadeInOut.leftClicked) {

                    FadeInOut.playInOut = true;
                    Main.mouseLeft = false;
                    FadeInOut.leftClicked = false;
                }
                    
                Filters.Scene.Deactivate("Distortion");
                Filters.Scene.Deactivate("FlashLight");
            }

            DarkDawn.infT += 0.15f;
            cosValue += 50;
            if(cameraShaking) {

                if(shakingValue < 1) shakingValue += 0.05f;
            }
            else {

                if(shakingValue > 0) shakingValue -= 0.05f;
            }
            if (Main.LocalPlayer.velocity != Vector2.Zero) {

                if(DarkDawn.dustSize > 0) DarkDawn.dustSize -= 0.05f;
            }
            else {

                if(DarkDawn.dustSize < 1f) DarkDawn.dustSize += 0.05f;
            }
        }
        public override void ModifyScreenPosition() {
            
            if (Main.LocalPlayer.dead) return;
            
            sqt = lerpValue * lerpValue;
            
            Main.screenPosition = Vector2.Lerp(
                Main.screenPosition,
                Main.MouseWorld - new Vector2(Main.screenWidth/2, Main.screenHeight/2) + // zoom parameters
                new Vector2(
                    shakingValue * shakingForce * (float)Math.Cos(MathHelper.ToRadians(cosValue)), // x shaking
                    shakingValue * shakingForce * (float)Math.Cos(MathHelper.ToRadians(2*cosValue)) // y shaking
                ),
                sqt / (2.0f * (sqt - lerpValue) + 1.0f));
            if (DarkDawn.isCasting) {

                delay = 0;
                if (lerpValue < 1) lerpValue += 0.03f;
            }
            else {

                delay++;

                if (delay > 10) {

                    if (Math.Sqrt(lerpValue) > 0)
                    lerpValue -= 0.03f;
                }
            }
        }
    }

    // loading custom music into biome
    public sealed class ManualMusicReg : ILoadable {
		public void Load(Mod mod) {

			MusicLoader.AddMusic(mod, "Assets/Music/DarkDawnOst");
		}
		public void Unload() { }
	}

    // setting dark color as bg to the biome (caves)
    public class DarkDawnUndergroundBackground : ModUndergroundBackgroundStyle {
        public override void FillTextureArray(int[] textureSlots) {

			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/DarkDawnBackground");
        }
    }

    // setting dark color as bg to the biome (surface)
    public class DarkDawnSurfaceBackground : ModSurfaceBackgroundStyle {
		public override void ModifyFarFades(float[] fades, float transitionSpeed) {
            // why i can't del it.... ty tML. ASHFSAHFHWEF STILL NOT FIXED BROOOO
		}
		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) {
            scale *= 100;
            a *= 0; // a = x copyright: tML team
            b *= 0; // b = y copyright: tML team
			return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/DarkDawnBackground");
		}
	}

    // setting up custom bg and music into game scene
    public class DarkDawnBiome : ModBiome {
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModUndergroundBackgroundStyle>("Conquest/DarkDawnUndergroundBackground");
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Conquest/DarkDawnSurfaceBackground");
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/DarkDawnOst"); // THEY WILL FEEL THE FEAR
        public override SceneEffectPriority Priority => SceneEffectPriority.BossHigh;
        public override bool IsBiomeActive(Player player) {

            bool b2 = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX) < Main.maxTilesX;

            if (player.active && DarkDawn.isCasting) {

                return true && b2;
            }
            else {

                return false;
            }           
        }
    }
    
    // some ui shit-coding for fade-in-out effect work
    internal class FadeInOut : UIState {
        private SoundStyle FadeSound = new SoundStyle("Conquest/Assets/Sounds/Fade");
        public static float fadeLerp;
        public static bool playInOut;
        private bool playIn;
        private bool playOut;
        private int inOutDelay;
        public static bool leftClicked;
        private UIElement screenArea;
        private UIImage blackScreen;
        public override void OnInitialize() {

			// area settings
			screenArea = new UIElement();
            SetRectangle(screenArea, 0f, 0f, Main.maxScreenW, Main.maxScreenH);
			screenArea.HAlign = 0f;
			screenArea.VAlign = 0f;
            screenArea.SetPadding(0);

			blackScreen = new UIImage(ModContent.Request<Texture2D>("Conquest/Projectiles/DarkDawnProjectiles/blankPixel"));
            SetRectangle(blackScreen, 0, 0, Main.maxScreenW, Main.maxScreenH);
            blackScreen.HAlign = 0f;
			blackScreen.VAlign = 0f;
            blackScreen.SetPadding(0);
            blackScreen.ScaleToFit = true;

			screenArea.Append(blackScreen);
			Append(screenArea);
		}

		// this function is for better rectangle setting; simple and useful
		private void SetRectangle(UIElement uiElement, float left, float top, float width, float height) {
            
			uiElement.Left.Set(left, 0f);
			uiElement.Top.Set(top, 0f);
			uiElement.Width.Set(width, 0f);
			uiElement.Height.Set(height, 0f);
		}

        // drawing a ui
		public override void Draw(SpriteBatch spriteBatch) {

			base.Draw(spriteBatch);
		}
		protected override void DrawSelf(SpriteBatch spriteBatch) {

			base.DrawSelf(spriteBatch);
		}

        // fadeinout effect function
        public void fadeInOut() {

            if(playInOut && !playIn && !playOut) {

                SoundEngine.PlaySound(FadeSound);
                playIn = true;
                playInOut = false;
            }
            if(playIn) {
                fadeLerp+=0.2f;
            }
            if(fadeLerp >= 1f && !playOut) {

                fadeLerp = 1f;
                playIn = false;
                inOutDelay++;
            }
            if(inOutDelay >= 60) {

                SoundEngine.PlaySound(FadeSound);
                playOut = true;
                inOutDelay = 0;
            }
            if(playOut) {

                fadeLerp-=0.2f;
            }
            if(fadeLerp <= 0f && !playIn) {

                fadeLerp = 0f;
                playOut = false;
            } 
        }
		public override void Update(GameTime gameTime) {
            
            fadeInOut(); //always enabled yes, because of color lerp below.
            SetRectangle(blackScreen, 0, 0, Main.maxScreenW, Main.maxScreenH);
            blackScreen.Color.A = (byte)MathHelper.Lerp(0, 255, fadeLerp); // opacity (alpha ch)
            
            if(Main.LocalPlayer.HeldItem.ModItem is not DarkDawn)
                return;

            // this calling fadeinout when clicking or unclicking btn
            if(leftClicked && !DarkDawn.isCasting) {

                leftClicked = false;
                playInOut = true;
            }
            if(!leftClicked && DarkDawn.isCasting) {

                leftClicked = true;
                playInOut = true;
            }

			base.Update(gameTime);
		}
	}

	// i've no idea what is this, i just copied it from my old project lmao
	class FadeInOutSystem : ModSystem {
		private UserInterface FadeInOutUserInterface;
		internal FadeInOut FadeInOutUI;
		public void ShowMyUI() {

			FadeInOutUserInterface?.SetState(FadeInOutUI);
		}
		public void HideMyUI() {

			FadeInOutUserInterface?.SetState(null);
		}
		public override void Load() {

			if (!Main.dedServ) {

				FadeInOutUI = new();
				FadeInOutUserInterface = new();
				FadeInOutUserInterface.SetState(FadeInOutUI);
			}
		}
		public override void UpdateUI(GameTime gameTime) {

			FadeInOutUserInterface?.Update(gameTime);
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {

			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != 100) {

				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Conquest: fadeinouteffect",
					delegate {

						FadeInOutUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
    }
}
