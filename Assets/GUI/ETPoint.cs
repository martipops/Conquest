using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using static Conquest.Assets.GUI.ETData;

namespace Conquest.Assets.GUI;

class ETPoint : ETButton {
    public int triNum, pointNum;

    public ETPoint(int trigramIndex, int pointIndex) : base(ModContent.Request<Texture2D>("Conquest/Assets/GUI/Point")){
        SetHoverImage(ModContent.Request<Texture2D>("Conquest/Assets/GUI/PointOn"));
        triNum = trigramIndex;
        pointNum = pointIndex;
        hoverOverride = Point.unlocked;
    }

    public PointData PrevPoint { get {return pointNum > 0 ? etPoints[triNum][pointNum-1] : null;} }
    public PointData Point { get {return etPoints[triNum][pointNum];} }
    public PointData NextPoint { get {return pointNum > etPoints[triNum].Length ? etPoints[triNum][pointNum+1] : null;} }

    public void TryUpgrade()
    {
        bool condition1 = PrevPoint == null || PrevPoint.unlocked;
        bool condition2 = tLoad + Point.loadValue <= tMaxLoad;
        bool condition3 = Point.RequirementsMet();
        
        Main.NewText($"Condition 1: {condition1}");
        Main.NewText($"Condition 2: {condition2}");
        Main.NewText($"Condition 3: {condition3}");

        if (condition1 && condition2 && condition3)
        {
            Point.unlocked = true;
            hoverOverride = true;
        }
    }

    public override void OnInitialize()
    {
        SetRectangle(Point.RelativeRect, etElmtDimensions);
        base.OnInitialize();
    }

    public override void MouseOut(UIMouseEvent evt)
    {
        EightTrigrams.infoPanel.Text = "";
        base.MouseOut(evt);
    }

    public override void MouseOver(UIMouseEvent evt)
    {
        if (!visible || pageIndex != triNum)
            return;
        EightTrigrams.infoPanel.Text = Point.GetTooltip();
        Main.NewText($"iopanel={EightTrigrams.infoPanel.X},{EightTrigrams.infoPanel.Y}");
        base.MouseOver(evt);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        if (!visible || pageIndex != triNum)
            return;
        base.DrawSelf(spriteBatch);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (!visible || pageIndex != triNum)
            return;
        base.Draw(spriteBatch);
    }
    public override void Update(GameTime gameTime)
    {
        if (!visible || pageIndex != triNum)
            return;
        if (IsMouseHovering) {
            EightTrigrams.infoPanel.Text = Point.GetTooltip();
        }
        base.Update(gameTime);
    }

}
