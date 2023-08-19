using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System.Linq;
using System.Collections.Generic;
using static Conquest.Assets.GUI.ETData;


namespace Conquest.Assets.GUI;

class ETTrigram : CQUIElement {

    public readonly int num;
    private Asset<Texture2D> triagramImage;
    public List<ETPoint> UIPoints = new();

    public ETTrigram(int num, Asset<Texture2D> triagramImage) {
        this.num = num;
        this.triagramImage = triagramImage;
        CreateElementsFromPointData();
    }
    
    public void CreateElementsFromPointData()
    {
        for (int i = 0; i < etPoints[num].Length; i++)
        {
           UIPoints.Add(new ETPoint(num, i));
        }
    }

    public override void OnInitialize()
    {
        UIImage triUIImage = new(triagramImage);
        
        SetRectangle(triUIImage, 
            etElmtDimensions.X, 
            etElmtDimensions.Y, 
            triUIImage.GetDimensions().Width, 
            triUIImage.GetDimensions().Height
        );
        Append(triUIImage);
    }

    public override void Draw(SpriteBatch spriteBatch) 
    {
        if (visible && pageIndex == num)
            base.Draw(spriteBatch);
    }

    public override void Update(GameTime gameTime)
    {
        if (visible && pageIndex == num)
            base.Update(gameTime);
    }
}
