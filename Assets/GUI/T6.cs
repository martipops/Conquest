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
    internal class T6 : UIState
    {
        SoundStyle Selected = new SoundStyle($"{nameof(Conquest)}/Assets/Sounds/Selected");
        private UIElement t6Elmt;
        private UIImage t6Img;

        public static Asset<Texture2D> t6p0;
        public static Asset<Texture2D> t6p1;
        public static Asset<Texture2D> t6p2;
        public static Asset<Texture2D> t6p3;
        public static Asset<Texture2D> t6p4;
        public static Asset<Texture2D> t6p5;
        public static Asset<Texture2D> t6p6;

        public static bool p31On = false;
        public static bool p32On = false;
        public static bool p33On = false;
        public static bool p34On = false;
        public static bool p35On = false;
        public static bool p36On = false;
        public static bool p37On = false;

        public override void OnInitialize()
        {
            t6Elmt = new UIElement();

            SetRectangle(t6Elmt, left: 320f, top: 0f, width: 1024f, height: 768f);


            t6Img = new UIImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/T6"));

            SetRectangle(t6Img, left: 320f, top: 0f, width: 384f, height: 384f);

            Append(t6Elmt);
            t6Elmt.Append(t6Img);
        }

        private void SetRectangle(UIElement uiElmt, float left, float top, float width, float height)
        {
            uiElmt.Left.Set(left, 0f);
            uiElmt.Top.Set(top, 0f);
            uiElmt.Width.Set(width, 0f);
            uiElmt.Height.Set(height, 0f);
        }

        private void T6P0InfoClose(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            EightTrigrams.infoImg.Remove();
        }
        private void T6P0Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 504f, top: 110f, width: 160f, height: 240f);

            if (p31On != true)
            {
                T1.txt1.SetText("Nourishment：\n+2% Summon Damage\n+1 Minion Slot\n\n\n\nLeft Click to activate\n+1 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            else
            {
                T1.txt1.SetText("Nourishment：\n+2% Summon Damage\n+1 Minion Slot\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }
            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P0On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 1 > EightTrigrams.tMaxLoad || p31On == true)
                return;

            p31On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 1;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T6P1Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p32On != true)
            {
                if (p31On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Super Minions：\n+2 Flat Damage\nfor summon weapons\n\n\n\nLeft Click to activate\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Super Minions：\n+2 Flat Damage\nfor summon weapons\n\n\nLocked！：\nSlay Eye of Cthulu\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p31On != true)
                {
                    T1.txt1.SetText("Super Minions：\n+2 Flat Damage\nfor summon weapons\n\nLocked！：\nYou need to unlock the\nthe previous talent first\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Super Minions：\n+2 Flat Damage\nfor summon weapons\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P1On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p32On == true || p31On == false || NPC.downedBoss1 == false)
                return;

            p32On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T6P2Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p33On != true)
            {
                if (p31On == true && NPC.downedBoss1 == true)
                {
                    T1.txt1.SetText("Marshal：\n+2 Minion Slots\n\n\n\n+2 Load\nLeft Click to activate\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (NPC.downedBoss1 != true)
                {
                    T1.txt1.SetText("Marshal：\n+2 Minion Slots\n\n\nLocked！：\n\nSlay Eye of Cthulu\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p31On != true)
                {
                    T1.txt1.SetText("Marshal：\n+2 Minion Slots\n\n\nLocked！：\nYou need to unlock the\nthe previous talent first\n+2 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Marshal：\n+2 Minion Slots\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P2On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 2 > EightTrigrams.tMaxLoad || p33On == true || p31On == false || NPC.downedBoss1 == false)
                return;

            p33On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 2;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T6P3Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p34On != true)
            {
                if (p32On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Savior：\nWhen you receive fatal\ndamage consume your\nminionsto revive yourself\n\n\nLeft Click to activate\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Savior：\nWhen you receive fatal\ndamage consume your\nminions to revive yourself\n\nLocked！：\nHard Mode\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p32On != true)
                {
                    T1.txt1.SetText("Savior：\nWhen you receive fatal\ndamage consume your\nminions to revive yourself\nLocked！：\nYou need to unlock the\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Savior：\nWhen you receive fatal\ndamage consume your\nminions to revive yourself\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P3On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p34On == true || p32On == false || Main.hardMode == false)
                return;

            p34On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T6P4Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p35On != true)
            {
                if (p33On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Willpower：\nAdds minion slots\nbased on max mana\n\n\nLeft Click to activate\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Willpower：\nAdds minion slots\nbased on max mana\n\n\nLocked！：\nHard Mode\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p33On != true)
                {
                    T1.txt1.SetText("Willpower：\nAdds minion slots\nbased on max mana\n\nLocked！：\nYou need to unlock the\nthe previous talent first\n+3 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Willpower：\nAdds minion slots\nbased non max mana\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P4On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 3 > EightTrigrams.tMaxLoad || p35On == true || p33On == false || Main.hardMode == false)
                return;

            p35On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 3;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        private void T6P5Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p36On != true)
            {
                if (p34On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Combined Attack：\nSummon weapons apply\nthe minion mark debuff\n\n\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Combined Attack：\nSummon weapons apply\nthe minion mark debuff\nLocked！：\nHard Mode\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p34On != true)
                {
                    T1.txt1.SetText("Combined Attack：\nSummon weapons apply\nthe minion mark debuff\nLocked！：\nYou need to unlock the\nthe previous talent first\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Combined Attack：\nSummon weapons apply\nthe minion mark debuff\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P5On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p36On == true || p34On == false || Main.hardMode == false)
                return;

            p36On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }


        private void T6P6Info(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tType != 6)
                return;

            SetRectangle(EightTrigrams.infoImg, left: 458f, top: 126f, width: 160f, height: 240f);

            if (p37On != true)
            {
                if (p35On == true && Main.hardMode == true)
                {
                    T1.txt1.SetText("Suppresive Fire：\nGain bonus damage\nbased on max minions\n\n\n\nLeft Click to activate\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (Main.hardMode != true)
                {
                    T1.txt1.SetText("Suppresive Fire：\nGain bonus damage\nbased on max minions\n\n\nLocked！：\nHard Mode\n4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
                else if (p35On != true)
                {
                    T1.txt1.SetText("Suppresive Fire：\nGain bonus damage\nbased on max minions\n\n\nLocked！：\nYou need to unlock the\nthe previous talent first\n+4 Load\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);

                }
            }
            else
            {
                T1.txt1.SetText("Suppresive Fire：\nGain bonus damage\nbased on max minions\n\n\n\n\nActivated！\nCurrent Load：" + EightTrigrams.loadInfoNow + "/" + EightTrigrams.loadInfoMax);
            }

            Append(EightTrigrams.infoImg);
            EightTrigrams.infoImg.Append(T1.txt1);
        }

        private void T6P6On(UIMouseEvent evt, UIElement listeningElement)
        {
            if (EightTrigrams.tLoad + 4 > EightTrigrams.tMaxLoad || p37On == true || p35On == false || Main.hardMode == false)
                return;

            p37On = true;
            SoundEngine.PlaySound(Selected);
            EightTrigrams.tLoad += 4;
            T1.txt1.Remove();
            EightTrigrams.infoImg.Remove();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (EightTrigrams.tType != 6 || EightTrigrams.vsb == false)
                return;

            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (EightTrigrams.tType != 6 || EightTrigrams.vsb == false)
                return;


            if (p31On != true)
            {
                t6p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p0 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P0 = new ETButton(t6p0, "T6P0");

            SetRectangle(playT6P0, left: 598f, top: 214f, width: 14f, height: 14f);

            playT6P0.OnMouseOver += new MouseEvent(T6P0Info);
            playT6P0.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P0.OnLeftClick += new MouseEvent(T6P0On);

            t6Elmt.Append(playT6P0);


            if (p32On != true)
            {
                t6p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p1 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P1 = new ETButton(t6p1, "T6P1");

            SetRectangle(playT6P1, left: 516f, top: 176f, width: 14f, height: 14f);

            playT6P1.OnMouseOver += new MouseEvent(T6P1Info);
            playT6P1.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P1.OnLeftClick += new MouseEvent(T6P1On);

            t6Elmt.Append(playT6P1);


            if (p33On != true)
            {
                t6p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p2 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P2 = new ETButton(t6p2, "T6P2");

            SetRectangle(playT6P2, left: 542f, top: 230f, width: 14f, height: 14f);

            playT6P2.OnMouseOver += new MouseEvent(T6P2Info);
            playT6P2.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P2.OnLeftClick += new MouseEvent(T6P2On);

            t6Elmt.Append(playT6P2);


            if (p34On != true)
            {
                t6p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p3 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P3 = new ETButton(t6p3, "T6P3");

            SetRectangle(playT6P3, left: 500f, top: 136f, width: 14f, height: 14f);

            playT6P3.OnMouseOver += new MouseEvent(T6P3Info);
            playT6P3.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P3.OnLeftClick += new MouseEvent(T6P3On);

            t6Elmt.Append(playT6P3);


            if (p35On != true)
            {
                t6p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p4 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P4 = new ETButton(t6p4, "T6P4");

            SetRectangle(playT6P4, left: 504f, top: 216f, width: 14f, height: 14f);

            playT6P4.OnMouseOver += new MouseEvent(T6P4Info);
            playT6P4.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P4.OnLeftClick += new MouseEvent(T6P4On);

            t6Elmt.Append(playT6P4);


            if (p36On != true)
            {
                t6p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p5 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P5 = new ETButton(t6p5, "T6P5");

            SetRectangle(playT6P5, left: 456f, top: 128f, width: 14f, height: 14f);

            playT6P5.OnMouseOver += new MouseEvent(T6P5Info);
            playT6P5.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P5.OnLeftClick += new MouseEvent(T6P5On);

            t6Elmt.Append(playT6P5);


            if (p37On != true)
            {
                t6p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point");
            }
            else
            {
                t6p6 = ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn");
            }

            ETButton playT6P6 = new ETButton(t6p6, "T6P6");

            SetRectangle(playT6P6, left: 464f, top: 212f, width: 14f, height: 14f);

            playT6P6.OnMouseOver += new MouseEvent(T6P6Info);
            playT6P6.OnMouseOut += new MouseEvent(T6P0InfoClose);

            playT6P6.OnLeftClick += new MouseEvent(T6P6On);

            t6Elmt.Append(playT6P6);
        }
    }
    class T6UISystem : ModSystem
    {
        private UserInterface t6Itfc;

        internal T6 eT6;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                eT6 = new();
                t6Itfc = new();
                t6Itfc.SetState(eT6);
            }
        }
        public override void UpdateUI(GameTime gameTime)
        {
            t6Itfc?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int etIdx = layers.FindIndex(layer => layer.Name.Equals("Conquest: EightTrigrams")) + 1;
            if (etIdx != -1)
            {
                layers.Insert(etIdx, new LegacyGameInterfaceLayer(
                    "Conquest: Trigram6",
                    delegate
                    {
                        t6Itfc.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                    )
                );
            }
        }
    }
}
