using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using static Terraria.Localization.Language;

namespace Conquest.Assets.GUI;

public class ETData
{

    public static int pageIndex = 0;

    public static int tLoad = 0;
    public static int tMaxLoad = 4;

    public static string loadInfoNow = tLoad.ToString();
    public static string loadInfoMax = tMaxLoad.ToString();

    public static Rectangle etElmtDimensions = new Rectangle(200, 0, Main.screenWidth, Main.screenHeight);

    public struct ETButtonInfo
    {
        public string TextureName; 
        public string HoverText;
        public Rectangle RelativeRect;
    }

    public static readonly ETButtonInfo[] buttonInfos = 
    {
        new ETButtonInfo { TextureName = "Q", HoverText = "Button0", RelativeRect = new Rectangle(0, 0, 32, 32) },
        new ETButtonInfo { TextureName = "ETB1", HoverText = "Button1", RelativeRect = new Rectangle(156, 0, 72, 72) },
        new ETButtonInfo { TextureName = "ETB2", HoverText = "Button2", RelativeRect = new Rectangle(48, 48, 72, 72) },
        new ETButtonInfo { TextureName = "ETB3", HoverText = "Button3", RelativeRect = new Rectangle(0, 156, 72, 72) },
        new ETButtonInfo { TextureName = "ETB4", HoverText = "Button4", RelativeRect = new Rectangle(48, 262, 72, 72) },
        new ETButtonInfo { TextureName = "ETB5", HoverText = "Button5", RelativeRect = new Rectangle(264, 48, 72, 72) },
        new ETButtonInfo { TextureName = "ETB6", HoverText = "Button6", RelativeRect = new Rectangle(312, 156, 72, 72) },
        new ETButtonInfo { TextureName = "ETB7", HoverText = "Button7", RelativeRect = new Rectangle(264, 262, 72, 72) },
        new ETButtonInfo { TextureName = "ETB8", HoverText = "Button8", RelativeRect = new Rectangle(156, 312, 72, 72) },
    };

    public static PointData[][] etPoints = new PointData[][] 
    {
        new PointData[] {
            new("ETSpiritVein", 0, 1, 184, 110),
            new("ETScorchingSpells", 1, 2, 138, 126),
            new("ETMagicReflux", 1, 2, 230, 122),
            new("ETResonance", 2, 3, 112, 162),
            new("ETMagicAbsorb", 2, 3, 264, 160),
            new("ETLandMine", 2, 4, 112, 218),
            new("ETStarSpirit", 2, 4, 264, 218)
        },
        new PointData[] {
            // new("ET", 0,10,10),
            // new("ET", 1,10,10),
            // new("ET", 1,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10)
        },
        new PointData[] {
            new("ETAnger", 0, 1, 96, 214),
            new("ETChargeSlot", 1, 2, 136, 162),
            new("ETSavings", 1, 2, 142, 236),
            new("ETWeakPoints", 2, 3, 172, 184),
            new("ETArmsMaster", 2, 3, 188, 242),
            new("ETPatience", 2, 4, 198, 134),
            new("ETHatTrick", 2, 4, 238, 216)
        },
        new PointData[] {
            // new("ET", 0,10,10),
            // new("ET", 1,10,10),
            // new("ET", 1,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10)
        },
        new PointData[] {
            // new("ET", 0,10,10),
            // new("ET", 1,10,10),
            // new("ET", 1,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10)
        },
        new PointData[] {
            new("ETNourishment", 0, 1, 278, 214),
            new("ETSuperMinion", 1, 2, 196, 176),
            new("ETMarshal", 1, 2, 222, 230),
            new("ETSavior", 2, 3, 180, 136),
            new("ETWillpower", 2, 3, 184, 216),
            new("ETCombinedAttack", 2, 4, 136, 128),
            new("ETSuppresiveFire", 2, 4, 144, 212)
        },
        new PointData[] {
            // new("ET", 0,10,10),
            // new("ET", 1,10,10),
            // new("ET", 1,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10),
            // new("ET", 2,10,10)
        },
        new PointData[] {
            new("ETStrength", 0, 1, 188, 266),
            new("ETDeadlyRhythm", 1, 2, 162, 252),
            new("ETBulwark", 1, 2, 212, 252),
            new("ETEgoism", 2, 3, 164, 190),
            new("ETBeastBlood", 2, 3, 208, 190),
            new("ETWarrior", 2, 4, 122, 156),
            new("ETUltragen", 2, 4, 250, 152)
        },
    };

    public static void ResetTriagrams (){
        tLoad = 0;
        for (int i = 0; i < etPoints.Length; i++)
            for (int j = 0; j < etPoints[i].Length; j++)
                etPoints[i][j].unlocked = false;
    }
}

public class PointData {
    public int reqirementLevel, loadValue;
    public Rectangle RelativeRect;
    public bool unlocked = false;
    public string keyName;
    private static readonly int SIZE = 14;

    public PointData(string keyName, int reqirementLevel, int loadValue, int x, int y)
    {
        this.keyName = keyName;
        this.reqirementLevel = reqirementLevel;
        this.loadValue = loadValue;
        RelativeRect = new(x, y, SIZE, SIZE);
    }


    public bool RequirementsMet() {
        switch (reqirementLevel) 
        {
            case 0:
            return true;
            case 1:
            return NPC.downedBoss1;
            case 2:
            return Main.hardMode;
        }
        return false;
    }

    public string GetTooltip()
    {
        StringBuilder sb = new(8);
        sb.AppendLine(GetText($"Mods.Conquest.GUI.EightTriagrams.{keyName}.Title").ToString());
        sb.AppendLine(GetText($"Mods.Conquest.GUI.EightTriagrams.{keyName}.Benefit").ToString());
        if (unlocked) {
            sb.AppendLine(GetText("Mods.Conquest.GUI.EightTriagrams.Activated").ToString());
        } else if (RequirementsMet()) {
                sb.AppendLine(GetText("Mods.Conquest.GUI.EightTriagrams.Unlockable").ToString());
        } else {
            switch (reqirementLevel) {
                case 1:
                sb.AppendLine(GetText("Mods.Conquest.GUI.EightTriagrams.NeedCthuluDefeat").ToString());
                break;
                case 2:
                sb.AppendLine(GetText("Mods.Conquest.GUI.EightTriagrams.NeedHardmode").ToString());
                break;
            }
        }
        sb.AppendLine(GetText("Mods.Conquest.GUI.EightTriagrams.CurrentLoad").ToString());
        sb.AppendLine($"{ETData.tLoad}/{ETData.tMaxLoad}");
        Main.NewText(sb.ToString());
        return sb.ToString();
    }
}