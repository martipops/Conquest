using System;
using System.Data.OracleClient;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.UI.Chat;

namespace Conquest.Assets.GUI;

public class CQTextBox : CQUIElement
{
    private Vector2 textSize;

    public int X;
    public int Y;
    public bool SnapToRightOfText = false;
    private string text;
    private static readonly int TEXT_PADDING = 10;

    public string Text 
    {
        get { return text; }
        set 
        {
            text = value;
            textSize = ChatManager.GetStringSize(FontAssets.MouseText.Value, Text, Vector2.One);
        }
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        if (text == null || text.Equals(""))
            return;
        Rectangle bgRect = new(X, Y, (int)textSize.X, (int)textSize.Y - 5);
        bgRect.Inflate(TEXT_PADDING, TEXT_PADDING);
        if(SnapToRightOfText)
            bgRect.X = X - (int) textSize.X;
        Utils.DrawInvBG(spriteBatch, bgRect);
        Utils.DrawBorderString(spriteBatch, Text, new Vector2(bgRect.X + TEXT_PADDING, bgRect.Y + TEXT_PADDING), Color.White);
    }


    internal void MoveToLocation(int x, int y)
    {
        X = x;
        Y = y;
    }
}
