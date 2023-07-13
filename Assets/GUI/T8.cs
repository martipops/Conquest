using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Audio;

using Terraria.GameInput;
using Terraria.ModLoader.UI.Elements;
using Conquest.Assets.GUI;

namespace Conquest.Assets.GUI

{
    internal class T8 : UIState
    {
        SoundStyle Selected = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Selected");

        Player player = Main.LocalPlayer;

        private UIElement t8Elmt;
        private UIImage t8Img;

        public static Asset<Texture2D> t8p0;
        public static Asset<Texture2D> t8p1;
        public static Asset<Texture2D> t8p2;
        public static Asset<Texture2D> t8p3;
        public static Asset<Texture2D> t8p4;
        public static Asset<Texture2D> t8p5;
        public static Asset<Texture2D> t8p6;

        public static bool p11On = false;
        public static bool p12On = false;
        public static bool p13On = false;
        public static bool p14On = false;
        public static bool p15On = false;
        public static bool p16On = false;
        public static bool p17On = false;

        public override void OnInitialize()
        {
            t8Elmt = new UIElement();

            SetRectangle(t8Elmt, left: 320f, top: 0f, width: 1024f, height: 768f);


            t8Img = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/T8"));

            SetRectangle(t8Img, left: 320f, top: 0f, width: 384f, height: 384f);

            Append(t8Elmt);
            t8Elmt.Append(t8Img);
        }

        private void T8P0InfoClose(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            EightTrigrams.infoImg.Remove();
        }

        private void T8P0Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 504f, top: 110f, width: 160f, height: 240f);

            if (p11On != true)
            {
                T1.txt1.SetText("Strength：\n+2% Melee Damage\n+20 Max Health\n\n\n\nLeft Click to activate\n+1 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            else
            {
                T1.txt1.SetText("Strength：\n+2% Melee Damage\n+20 Max Health\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P0On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 1 > EightTrigrams.tMaxLoad || p11On == true)
                return;

            p11On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 1;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T8P1Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p12On != true)
            {
                if (p11On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Deadly Rhythm：\nHitting the same target\nincreases melee speed\n\n\n\nLeft Click to activate\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Deadly Rhythm：\nHitting the same target\nincreases melee speed\nLocked！：\n\nSlay Eye of Cthulu\n\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p11On != true)
                {
                    T1.txt1.SetText("Deadly Rhythm：\nHitting the same target\nincreases melee speed\nLocked！：\nYou need to unlock\nthe previous talent firs\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Deadly Rhythm：\nHitting the same target\nincreases melee speed\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P1On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p12On == true || p11On == false || NPC.downedBoss1 == false)
                return;

            p12On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T8P2Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p13On != true)
            {
                if (p11On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Bulwark：\nProvides damage reduction\nfor a short period\nafter a true melee strike\nLeft Click to activate\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Bulwark：\nProvides damage reduction\nfor a short period\nafter a true melee strike\nLocked！：\nSlay Eye of Cthulu\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p11On != true)
                {
                    T1.txt1.SetText("Bulwark：\nProvides damage reduction\nfor a short period\nafter a true melee strike\nLocked！：\nYou need to unlock\nthe previous talent first\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Bulwark：\nProvides damage reduction\nfor a short period\nafter a true melee strike\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }


        private void T8P2On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p13On == true || p11On == false || NPC.downedBoss1 == false)
                return;

            p13On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T8P3Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p14On != true)
            {
                if (p12On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Egoism：\nIncreases melee damage\nbased on movement speed\nand attack speed\n\n\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Egoism：\nIncreases melee damage\nbased on movement speed\nand attack speed\n\nLocked！：\nHard Mode\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p12On != true)
                {
                    T1.txt1.SetText("Egoism：\nIncreases melee damage\nbased on movement speed\nand attack speed\nLocked！：\nYou need to unlock\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Egoism：\nIncreases melee damage\nbased on movement speed\nand attack speed\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P3On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p14On == true || p12On == false || Main.hardMode == false)
                return;

            p14On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T8P4Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p15On != true)
            {
                if (p13On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Beast Blood：\nNon-Lethal damage is\nconverted to lost life\nwhich can be recovered\nby attacking enemies\n\nLeft Click to activate\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Beast Blood：\nNon-Lethal damage is\nconverted to lost life\nwhich can be recovered\nby attacking enemies\nLocked！：\nHard Mode\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p13On != true)
                {
                    T1.txt1.SetText("Beast Blood：\nNon-Lethal damage is\nconverted to lost life\nwhich can be recovered\nby attacking enemies\nLocked！：\nYou need to unlock\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Beast Blood：\nNon-Lethal damage is\nconverted to lost life\nwhich can be recovered\nby attacking enemies\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P4On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p15On == true || p13On == false || Main.hardMode == false)
                return;

            p15On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T8P5Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p16On != true)
            {
                if (p14On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Warrior：\nIncreases attack speed based\non current health\n\n\n\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Warrior：\nIncreases attack speed based\non current health\n\n\nLocked！：\nHard Mode\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p14On != true)
                {
                    T1.txt1.SetText("Warrior：\nIncreases attack speed based\non current health\n\nLocked！：\nYou need to unlock\nthe previous talent first\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Warrior：\nIncreases attack speed based\non current health\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P5On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p16On == true || p14On == false || Main.hardMode == false)
                return;

            p16On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T8P6Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 8)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p17On != true)
            {
                if (p15On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Ultragen：\nIncreases life regeneration\nbased on max health\n\n\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Ultragen：\nIncreases life regeneration\nbased on max health\nLocked！：\nHard Mode\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p15On != true)
                {
                    T1.txt1.SetText("Ultragen：\nIncreases life regeneration\nbased on max health\nLocked！：\nYou need to unlock\nthe previous talent firs\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Ultragen：\nIncreases life regeneration\nbased on max health\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T8P6On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p17On == true || p15On == false || Main.hardMode == false)
                return;

            p17On = true;
            SoundEngine.PlaySound(Selected);

            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void SetRectangle(UIElement uiElmt, float left, float top, float width, float height)
        {
            uiElmt.Left.Set(left, 0f);
            uiElmt.Top.Set(top, 0f);
            uiElmt.Width.Set(width, 0f);
            uiElmt.Height.Set(height, 0f);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (EightTrigrams.tType != 8 || EightTrigrams.vsb == false)
                return;

            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (EightTrigrams.tType != 8 || EightTrigrams.vsb == false)
                return;

            if (p11On != true)
            {
                t8p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P0 = new ETButton(t8p0, "T8P0");

            SetRectangle(playT8P0, left: 508f, top: 266f, width: 14f, height: 14f);

            playT8P0.OnMouseOver += new MouseEvent(T8P0Info);
            playT8P0.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P0.OnLeftClick += new MouseEvent(T8P0On);

            t8Elmt.Append(playT8P0);


            if (p12On != true)
            {
                t8p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P1 = new ETButton(t8p1, "T8P1");

            SetRectangle(playT8P1, left: 482f, top: 252f, width: 14f, height: 14f);

            playT8P1.OnMouseOver += new MouseEvent(T8P1Info);
            playT8P1.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P1.OnLeftClick += new MouseEvent(T8P1On);

            t8Elmt.Append(playT8P1);


            if (p13On != true)
            {
                t8p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P2 = new ETButton(t8p2, "T8P2");

            SetRectangle(playT8P2, left: 532f, top: 252f, width: 14f, height: 14f);

            playT8P2.OnMouseOver += new MouseEvent(T8P2Info);
            playT8P2.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P2.OnLeftClick += new MouseEvent(T8P2On);

            t8Elmt.Append(playT8P2);


            if (p14On != true)
            {
                t8p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P3 = new ETButton(t8p3, "T8P3");

            SetRectangle(playT8P3, left: 484f, top: 190f, width: 14f, height: 14f);

            playT8P3.OnMouseOver += new MouseEvent(T8P3Info);
            playT8P3.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P3.OnLeftClick += new MouseEvent(T8P3On);

            t8Elmt.Append(playT8P3);


            if (p15On != true)
            {
                t8p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P4 = new ETButton(t8p4, "T8P4");

            SetRectangle(playT8P4, left: 528f, top: 190f, width: 14f, height: 14f);

            playT8P4.OnMouseOver += new MouseEvent(T8P4Info);
            playT8P4.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P4.OnLeftClick += new MouseEvent(T8P4On);

            t8Elmt.Append(playT8P4);


            if (p16On != true)
            {
                t8p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P5 = new ETButton(t8p5, "T8P5");

            SetRectangle(playT8P5, left: 442f, top: 156f, width: 14f, height: 14f);

            playT8P5.OnMouseOver += new MouseEvent(T8P5Info);
            playT8P5.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P5.OnLeftClick += new MouseEvent(T8P5On);

            t8Elmt.Append(playT8P5);


            if (p17On != true)
            {
                t8p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t8p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT8P6 = new ETButton(t8p6, "T8P6");

            SetRectangle(playT8P6, left: 570f, top: 152f, width: 14f, height: 14f);

            playT8P6.OnMouseOver += new MouseEvent(T8P6Info);
            playT8P6.OnMouseOut += new MouseEvent(T8P0InfoClose);

            playT8P6.OnLeftClick += new MouseEvent(T8P6On);

            t8Elmt.Append(playT8P6);
        }
    }

    class T8UISystem : ModSystem
    {
        private UserInterface t8Itfc;

        internal T8 eT8;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                eT8 = new();
                t8Itfc = new();
                t8Itfc.SetState(eT8);
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            t8Itfc?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int etIdx = layers.FindIndex(layer => layer.Name.Equals("Conquest: EightTrigrams")) + 1;
            if (etIdx != -1)
            {
                layers.Insert(etIdx, new LegacyGameInterfaceLayer(
                    "Conquest: Trigram8",
                    delegate
                    {
                        t8Itfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }
        }
    }
}
