using System;
using System.Text.Json.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace puzzle_game;

public class Lvl
{
    public string Name { get; set; }
    public int[][] Background { get; set; }
    public int[][] Layout { get; set; }

    public void Draw(SpriteBatch spriteBatch)
    {
        Console.WriteLine(Layout.Length + ',' + Layout[0].Length);
        for(int i = 0; i < 12; i++)
            for(int j = 0; j < 12; j++)
                if (Layout[i][j] != 0)
                    spriteBatch.Draw(
                        Puzzle.spriteSheet,
                        new Rectangle(i * 80, j * 80, 80, 80),
                        Color.White
                    );
    }
}