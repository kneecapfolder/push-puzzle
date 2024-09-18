using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace puzzle_game;

public class Player
{
    public Vector2 pos;
    public int dir;
    
    public Player(Vector2 pos)
    {
        this.pos = pos;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            Puzzle.spriteSheet,
            new Rectangle((int)pos.X * 80, (int)pos.Y * 80, 80, 80),
            new Rectangle(dir * 16, 0, 16, 16),
            Color.White
        );
    }
}