using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace puzzle_game;

public class Puzzle : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    public static Texture2D spriteSheet;
    private List<Lvl> lvls;
    private Lvl level;
    private KeyboardState lastState;

    private Player player = new Player(Vector2.Zero);

    public Puzzle()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        graphics.PreferredBackBufferWidth = 960;
        graphics.PreferredBackBufferHeight = 960;
        graphics.ApplyChanges();
        
        lvls = Read<List<Lvl>>("../../../data/lvls.json");
        level = lvls[0];

        lastState = Keyboard.GetState();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        spriteSheet = Content.Load<Texture2D>(".sprites/spritesheet");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        if (lastState.IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.W))
        {
            player.pos.Y--;
            player.dir = 2;
        }
        if (lastState.IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.S))
        {
            player.pos.Y++;
            player.dir = 0;
        }
        if (lastState.IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.A))
        {
            player.pos.X--;
            player.dir = 3;
        }
        if (lastState.IsKeyUp(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.D))
        {
            player.pos.X++;
            player.dir = 1;
        }
        lastState = Keyboard.GetState();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        level.Draw(spriteBatch);
        player.Draw(spriteBatch);

        spriteBatch.End();

        base.Draw(gameTime);
    }

    public static T Read<T>(string filePath)
    {
        string text = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(text);
    }
}
