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
        for(int i = 0; i < 12; i++)
            for(int j = 0; j < 12; j++)
                if (Layout[i][j] != 0)
                    spriteBatch.Draw(
                        Puzzle.spriteSheet,
                        new Rectangle(i * 80, j * 80, 80, 80),
                        new Rectangle((Layout[i][j]-1) * 16, 16, 16, 16),
                        Color.White
                    );
    }
}